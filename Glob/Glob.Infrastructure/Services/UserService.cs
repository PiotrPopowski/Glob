using Glob.Core.Domain;
using Glob.Infrastructure.Framework;
using Glob.Infrastructure.Properties;
using Glob.Infrastructure.Requests;
using Glob.Infrastructure.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.IAesHandler;

namespace Glob.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ICryptographyProvider _cryptographyProvider;
        private readonly IPropertyHandler _propertyHandler;
        private readonly UserSettings _userSettings;

        public User User { get { return _userSettings==null?null:_userSettings.User; } }
        public UserService(ICryptographyProvider cryptographyProvider, IPropertyHandler propertyHandler, UserSettings userSettings)
        {
            _cryptographyProvider = cryptographyProvider;
            _propertyHandler = propertyHandler;
            _userSettings = userSettings;
        }
        public async Task<User> Login(string login, string password)
        {
            var properties = _propertyHandler.Load();
            if(login != properties.Login)
            {
                throw new ArgumentException("Zły login");
            }
            if(password != properties.Password)
            {
                throw new ArgumentException("Złe hasło");
            }
            var request = new UserRequest() { Login = login, Password = password };
            var jwt = await HttpClientWrapper.PostAsync<Jwt>(ApiEndpoints.Login, request);
            HttpClientWrapper.Authenticate(jwt.Token);
            var user = jwt.User;
            user.Token = jwt.Token;
            if(user == null)
            {
                throw new Exception("Nie znaleziono użytkownika w bazie.");
            }

            user.Password = properties.Password;
            user.PublicKey = properties.PublickKey;
            user.PrivateKey = properties.PrivateKey;

            var newContacts = await HttpClientWrapper.GetAsync<List<NewContact>>(ApiEndpoints.NewContacts);
            if(newContacts != null)
            {
                foreach(var newContact in newContacts)
                {
                    var key = _cryptographyProvider.RSA.Decrypt(newContact.SymmetricKey, user.PrivateKey);
                    var iv = _cryptographyProvider.RSA.Decrypt(newContact.IV, user.PrivateKey);
                    properties.Keys.Add(newContact.ContactName, new AesKey(key, iv));
                }
                _propertyHandler.Save(properties);
            }

            _userSettings.User = user;
            _userSettings.Keys = properties.Keys;
            return user;
        }

        public async Task Register(string login, string firstName, string lastName, string password)
        {
            var keys = _cryptographyProvider.RSA.GeneratePubPrivKeys();
            var request = new UserRequest() { Login = login, FirstName = firstName, LastName = lastName, Password = password, PublicKey = keys.PublicKey };
            await HttpClientWrapper.PostAsync(ApiEndpoints.Register, request);

            var properties = Properties.Properties.Create();
            properties.Login = login;
            properties.Password = password;
            properties.PublickKey = keys.PublicKey;
            properties.PrivateKey = keys.PrivateKey;
            properties.Keys = new Dictionary<string, AesKey>();
            _propertyHandler.Save(properties);
        }

        public async Task<User> Refresh()
        {
           var user = await Login(_userSettings.User.Login, _userSettings.User.Password);
            _userSettings.User = user;
            return user;
        }

        public async Task<Contact> AddContact(string login)
        {
            var contact = await HttpClientWrapper.GetAsync<Contact>(ApiEndpoints.GetUserInfo(login));
            var key = _cryptographyProvider.AES.CreateKey();
            var request = new AddContactRequest()
            {
                ContactName = login,
                SymmetricKey = _cryptographyProvider.RSA.Encrypt(key.Key, contact.PublicKey),
                IV = _cryptographyProvider.RSA.Encrypt(key.IV, contact.PublicKey)
            };
            contact = await HttpClientWrapper.PostAsync<Contact>(ApiEndpoints.Add(_userSettings.User.Login, login), request);
            
            var properties = _propertyHandler.Load();
            properties.Keys.Add(login, key);
            _propertyHandler.Save(properties);
            _userSettings.Keys.TryAdd(login, key);

            _userSettings.User.Contacts.Add(contact);
            return contact;
        }
    }
}

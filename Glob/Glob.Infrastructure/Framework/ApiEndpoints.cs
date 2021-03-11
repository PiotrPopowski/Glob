using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Framework
{
    public static class ApiEndpoints
    {
        public static string Domain => "https://localhost:5001/api";
        public static string SignalChat => "http://localhost:5000/chat";
        public static string NewContacts => Domain + "/User/Me/News";
        public static string GetUserInfo(string login) => Domain + $"/User/info/{login}";
        public static string Login => Domain + "/User/signIn";
        public static string Register => Domain + "/User/register";
        public static string AllConversation => Domain + "/Conversation/GetAll";
        public static string SingleConversation(string contact) => Domain + $"/Conversation/Get/{contact}";
        public static string Add(string userLogin, string contactLogin) => Domain + $"/User/add/{userLogin}-{contactLogin}";
    }
}

using Glob.Infrastructure.Properties;
using Glob.Infrastructure.Services;
using Glob.Infrastructure.Settings;
using Glob.UI.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glob.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder()
             .ConfigureAppConfiguration((context, builder) =>
             {
                 builder.AddJsonFile("appsettings.local.json", optional: true);
             })
             .ConfigureServices((context, services) =>
             {
                 ConfigureServices(context.Configuration, services);
             })
             .Build();

            var services = host.Services;
            var propertyHandler = services.GetRequiredService<IPropertyHandler>();
            var properties = propertyHandler.Load();
            BaseForm startForm;
            if (properties == null)
            {
                startForm = services.GetRequiredService<RegisterForm>();
            }
            else
            {
                startForm = services.GetRequiredService<LoginForm>();
            }

            IFormManager formManager = new FormManager(startForm, services);
            Application.Run(formManager.ActiveForm);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<IPropertyHandler, PropertyHandler>();
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<ICryptographyProvider, CryptographyProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<UserSettings>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAesHandler, AesHandler>();
            services.AddScoped<IRSAHandler, RSAHandler>();

            services.AddSingleton<MainForm>();
            services.AddSingleton<LoginForm>();
            services.AddSingleton<RegisterForm>();
        }
    }
}

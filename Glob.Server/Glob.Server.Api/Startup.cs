using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Glob.Server.Core.Contexts;
using Glob.Server.Infrastructure.Framework;
using Glob.Server.Infrastructure.Hubs;
using Glob.Server.Infrastructure.Repositories;
using Glob.Server.Infrastructure.Services;
using Glob.Server.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;

namespace Glob.Server.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GlobContext>(opt => opt.UseInMemoryDatabase("GlobContext"));

            var jwtOptions = new JwtSettings()
            {
                Issuer = "Glob",
                Key = "supersecretkey12345eewqhiuehwiurejqwo%e",
                ValidTime = 240
            };
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(c =>
               {
                   c.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                       ValidIssuer = jwtOptions.Issuer,
                       ValidateAudience = false,
                       ValidateLifetime = true
                   };
                   c.Events = new JwtBearerEvents()
                   {
                       OnMessageReceived = context =>
                       {
                           var accessToken = context.Request.Headers["Auth"].FirstOrDefault();
                           // If the request is for our hub...
                           var path = context.HttpContext.Request.Path;
                           if (!string.IsNullOrEmpty(accessToken) &&
                               (path.StartsWithSegments("/chat")))
                           {
                               // Read the token out of the query string
                               context.Token = accessToken;
                           }
                           return Task.CompletedTask;
                       }
                   };
               });

            services.AddSingleton<IJwtHandler, JwtHandler>(x => new JwtHandler(jwtOptions));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IChatService, ChatService>();
            services.AddSingleton<IMapper>(x => AutoMapperConfig.InitializeMapper());
            services.AddSingleton<IEncrypter, Encrypter>();

            var signalRServices = services.AddSignalR().Services;
            /*signalRServices.AddScoped<IUserService, UserService>();
            signalRServices.AddScoped<IChatRepository, ChatRepository>();
            signalRServices.AddScoped<IChatService, ChatService>();*/

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Glob.Server.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Glob.Server.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}

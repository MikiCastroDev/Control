using Control.Core.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Control.Core.UI.DIContainer
{
    public static class Configurator
    {
        public static void Configure(IServiceCollection services, ConfigurationManager configurator)
        {
            //services.AddDbContextFactory<>(options);
            services.AddScoped<UsersService>();
            ConfigureAuth(services, configurator);
        }

        private static void ConfigureAuth(IServiceCollection services, ConfigurationManager configurator)
        {
            string tokenKey = configurator.GetSection("settings")["token-key"];
            int timeToExpired = Int32.Parse(configurator.GetSection("settings")["time-to-expired"]);

            services.AddAuthorization();
            services.AddSingleton(new TokenService(tokenKey, timeToExpired));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    LifetimeValidator = LifetimeValidator,
                    ValidateIssuerSigningKey = true
                };
            });
        }

        private static bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken token, TokenValidationParameters @params)
        {
            if (expires != null)
                return expires > DateTime.UtcNow;

            return false;
        }
    }
}

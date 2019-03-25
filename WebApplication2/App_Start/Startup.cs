using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(WebApplication2.App_Start.Startup))]

namespace WebApplication2.App_Start
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        IUserService serviceCreator;
        public void Configuration(IAppBuilder app)
        {

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };
            app.UseOAuthBearerTokens(OAuthOptions);

        }

        private IUserService CreateUserService()
        {
            return new UserService(new EFUnitOfWork("ServiceForTesting"));
        }
    }
}

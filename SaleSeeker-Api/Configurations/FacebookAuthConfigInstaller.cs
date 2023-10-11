using SaleSeeker_Api.Models.Auth;
using SaleSeeker_Api.Services.Auth;

namespace SaleSeeker_Api.Configurations
{
    public class FacebookAuthConfigInstaller : IInstaller
    {
        public static void InstallServices(WebApplicationBuilder builder, IConfiguration configuration)
        {
            var facebookAuthSettings = new FacebookOAuthSettings();
            configuration.Bind(nameof(FacebookOAuthSettings), facebookAuthSettings);

            builder.Services.AddSingleton(facebookAuthSettings);
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IFacebookOAuthService, FacebookOAuthService>();
        }
    }
}

using Newtonsoft.Json;
using SaleSeeker_Api.Classes;
using SaleSeeker_Api.Models.Auth;

namespace SaleSeeker_Api.Services.Auth
{
    public class FacebookOAuthService : IFacebookOAuthService
    {
        private const string _tokenValidationUrl = APIConstants.TokenValidationUrl;
        private const string _userInfoUrl = APIConstants.UserInfoUrl;
        private readonly FacebookOAuthSettings _facebookOAuthSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        public FacebookOAuthService(FacebookOAuthSettings facebookOAuthSettings, IHttpClientFactory httpClientFactory)
        {
            _facebookOAuthSettings = facebookOAuthSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken)
        {
            try
            {
                var url = string.Format(_userInfoUrl, accessToken);
                var results = await _httpClientFactory.CreateClient().GetAsync(url);
                results.EnsureSuccessStatusCode();
                var responseAsString = await results.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FacebookUserInfoResult>(responseAsString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FaceBookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            try
            {
                var url = string.Format(_tokenValidationUrl, accessToken, _facebookOAuthSettings.AppId, _facebookOAuthSettings.AppSecret);
                var results = await _httpClientFactory.CreateClient().GetAsync(url);
                results.EnsureSuccessStatusCode();
                var responseAsString = await results.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FaceBookTokenValidationResult>(responseAsString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

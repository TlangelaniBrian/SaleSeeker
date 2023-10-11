using SaleSeeker_Api.Models.Auth;

namespace SaleSeeker_Api.Services.Auth
{
    public interface IFacebookOAuthService
    {
        Task<FaceBookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}

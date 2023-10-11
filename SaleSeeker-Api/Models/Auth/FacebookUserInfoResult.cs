using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SaleSeeker_Api.Models.Auth
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class FacebookUserInfoResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public FacebookPicture FacebookPicture { get; set; }
    }

    public class FacebookPicture
    {
        public FacebookPictureData FacebookPictureData { get; set; }
    }

    public class FacebookPictureData
    {
        public long Height { get; set; }
        public bool IsSilhouette { get; set; }
        public Uri Url { get; set; }
        public long Width { get; set; }
    }
}

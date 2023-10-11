using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SaleSeeker_Api.Models.Auth
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class FaceBookTokenValidationResult
    {
        public FaceBookTokenValidationData Data { get; set; }
    }

    public class FaceBookTokenValidationData
    {
        public string AppId { get; set; }
        public string Type { get; set; }
        public string Application { get; set; }
        public long DataAccessExpiresAt { get; set; }
        public long ExpiresAt { get; set; }
        public bool IsValid { get; set; }
        public string[] Scopes { get; set; }
        public string UserId { get; set; }
    }
}

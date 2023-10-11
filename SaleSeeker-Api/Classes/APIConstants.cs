namespace SaleSeeker_Api.Classes
{
    public static class APIConstants
    {
        public const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        public const string UserInfoUrl = "https://graph.facebook.com/me?fields=id,name,email,picture&access_token={0}";
    }
}

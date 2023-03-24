using Newtonsoft.Json;

namespace RestSharpTest.DataModels
{
    public class TokenModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

        [JsonProperty("password")]
        public string Password { get; set; }
    }                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

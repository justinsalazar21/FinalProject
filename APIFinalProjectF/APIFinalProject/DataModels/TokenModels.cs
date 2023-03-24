using Newtonsoft.Json;


namespace HttpClientTest.DataModels
{
    public class TokenModels
    {
        [JsonProperty("username")]
        public string Username { get; set; }                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

        [JsonProperty("password")]
        public string Password { get; set; }
    }
    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
    }
}

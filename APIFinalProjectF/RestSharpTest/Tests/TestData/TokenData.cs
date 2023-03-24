using RestSharpTest.DataModels;

namespace RestSharpTest.Tests.TestData
{
    public class TokenData
    {
        public static TokenModel generateToken()                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
        {
            return new TokenModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}

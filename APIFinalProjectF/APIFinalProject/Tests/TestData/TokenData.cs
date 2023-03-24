using HttpClientTest.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTest.Tests.TestData
{
    public class TokenData
    {
        public static TokenModels generateToken()                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
        {
            return new TokenModels
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}

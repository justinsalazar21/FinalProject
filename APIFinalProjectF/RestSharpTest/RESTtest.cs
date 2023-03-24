using RestSharp;

namespace RestSharpTest.Tests
{
    public class RESTtest
    {
        public RestClient RestClient { get; set; }                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

    }
}


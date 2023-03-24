using ServiceReference1;


namespace soapTestFinalFinal
{
    [TestClass]
    public class soapTestFinals
    {

        //Global Variable
        private readonly ServiceReference1.CountryInfoServiceSoapTypeClient soapTestFinalFinal =
             new ServiceReference1.CountryInfoServiceSoapTypeClient(ServiceReference1.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

        [TestMethod]
        private List<tCountryCodeAndName> GetCountryCodeAndNameList()
        {
            return soapTestFinalFinal.ListOfCountryNamesByCode();
        }

        [TestMethod]
        private static tCountryCodeAndName GetRandomRecord(List<tCountryCodeAndName> countryList)
        {
            //randomizing
            Random rnd = new Random();

            int rndInt = rnd.Next(0, countryList.Count);
            
            var randomCountry = countryList[rndInt];

            return randomCountry;
        }

        [TestMethod]
        public void Test1()
        {
            //initialization of the critereas 
            var countryList = GetCountryCodeAndNameList();
            var randomCountry = GetRandomRecord(countryList);
            var randomCountryDetails = soapTestFinalFinal.FullCountryInfo(randomCountry.sISOCode);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

            //assertion
            Assert.AreEqual(randomCountryDetails.sISOCode, randomCountry.sISOCode);
            Assert.AreEqual(randomCountryDetails.sName, randomCountry.sName);
        }

        [TestMethod]
        public void Test2()
        {
            //initialization of the critereas
            var countryList = GetCountryCodeAndNameList();
            var randomCountry = GetRandomRecord(countryList);
            //getting 5 countries
            var get5 = countryList.OrderBy(o => o.sISOCode).Take(5);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

            //Assertions
            foreach (var country in get5)
            {
                Assert.AreEqual(country.sISOCode, country.sISOCode);
            }
        }
    }
}
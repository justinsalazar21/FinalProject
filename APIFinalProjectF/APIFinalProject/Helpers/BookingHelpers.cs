using HttpClientTest.DataModels;
using HttpClientTest.Resources;
using HttpClientTest.Tests.TestData;
using Newtonsoft.Json;
using System.Text;

namespace HttpClientTest.Helpers
{
    public class BookingHelpers
    {
        public static async Task <HttpResponseMessage> CreateNewBookingData()
        {
            //initialization
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(BookingData.demoBooking());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");

            //Post Request
            return await httpClient.PostAsync(BookingResources.GetURL(BookingResources.BookingEndPoint), postRequest);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023


        }
        public static async Task<HttpResponseMessage> GetBookingDataById(long id)
        {
            //initialization
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            //Get Request
            return await httpClient.GetAsync(BookingResources.GetURL(BookingResources.BookingEndPoint) + "/" + id);
            
        }
        public static async Task<HttpResponseMessage> UpdateBookingDataById(long id, Booking objectModel)
        {
            //initialization
            var httpClient = new HttpClient();
            var token = await CreateToken();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);

            var request = JsonConvert.SerializeObject(objectModel);
            var putRequest = new StringContent(request, Encoding.UTF8, "application/json");

            //put request
            return await httpClient.PutAsync(BookingResources.GetURL(BookingResources.BookingEndPoint) + "/" + id, putRequest);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023


        }
        public static async Task<HttpResponseMessage> DeleteBookingDataById(long id)
        {
            //initialization
            var httpClient = new HttpClient();
            var token = await CreateToken();

            //delete request
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);
            
            return await httpClient.DeleteAsync(BookingResources.GetURL(BookingResources.BookingEndPoint) + "/" + id);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

        }
        public static async Task<string> CreateToken()
        {
            //initialization
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(TokenData.generateToken());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");

            //Post Request
            var httpResponse = await httpClient.PostAsync("https://restful-booker.herokuapp.com/auth", postRequest);
            var token = JsonConvert.DeserializeObject<TokenResponse>(httpResponse.Content.ReadAsStringAsync().Result);

            return token.Token;
        }
    }
}

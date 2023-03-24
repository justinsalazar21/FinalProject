using RestSharpTest.DataModels;
using RestSharp;
using RestSharpTest.Tests.TestData;
using RestSharpTest.Resources;

namespace RestSharpTest.Helpers;

public class BookingHelpers
{
    public static async Task<RestResponse<BookingModels>> CreateNewBookingData(RestClient restClient)                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
    {
        //initialization
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");

        //post request
        var postRequest = new RestRequest(BookingResources.GetURL(BookingResources.BookingEndPoint)).AddJsonBody(BookingData.demoBooking());                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
        return await restClient.ExecutePostAsync<BookingModels>(postRequest);
        
    }
    public static async Task<RestResponse<Booking>> GetBookById(RestClient restClient, long id)
    {
        //initialization
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");

        //get request
        var getRequest = new RestRequest(BookingResources.GetUri(BookingResources.BookingEndPoint) + "/" + id);
        return await restClient.ExecuteGetAsync<Booking>(getRequest);
        
    }
    public static async Task<RestResponse<Booking>> UpdateBookingData(RestClient restClient, long id, Booking objectModel)                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
    {
        //initialization
        restClient = new RestClient();
        var token = await CreateToken(restClient);

        restClient.AddDefaultHeader("Accept", "application/json");
        restClient.AddDefaultHeader("Cookie", "token=" + token);//using token to update data

        //Put request
        var putRequest = new RestRequest(BookingResources.GetUri(BookingResources.BookingEndPoint) + "/" + id).AddJsonBody(objectModel);
        return await restClient.ExecutePutAsync<Booking>(putRequest);

    }
    public static async Task<RestResponse> DeleteBookingData(RestClient restClient, long id)
    {
        //initialization
        restClient = new RestClient();
        var token = await CreateToken(restClient);

        restClient.AddDefaultHeader("Accept", "application/json");
        restClient.AddDefaultHeader("Cookie", "token=" + token);//using token to delete data also this i used this for cleanup

        //delete request
        var deleteRequest = new RestRequest(BookingResources.GetUri(BookingResources.BookingEndPoint) + "/" + id);
        return await restClient.DeleteAsync(deleteRequest);  

    }
    public static async Task<string> CreateToken(RestClient restClient)
    {
        //initialization
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");

        //post request
        var postRequest = new RestRequest("https://restful-booker.herokuapp.com/auth").AddJsonBody(TokenData.generateToken());                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
        var postResponse = await restClient.ExecutePostAsync<TokenResponse>(postRequest);

        return postResponse.Data.Token;
    }
}

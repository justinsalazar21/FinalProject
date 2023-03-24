using HttpClientTest.DataModels;
using Newtonsoft.Json;
using System.Net;
using HttpClientTest.Helpers;
using RestSharp;


namespace HttpClientTest.Tests
{
    [TestClass]
    public class HttpClientTests
    {

        [TestMethod]
        public async Task CreateNewBookingDetails()
        {
            //Creating a new booking data
            var postResponse = await BookingHelpers.CreateNewBookingData();
      
            //Act
            var postCreatedBooking = JsonConvert.DeserializeObject<BookingModels>(postResponse.Content.ReadAsStringAsync().Result);
            var getResponse = await BookingHelpers.GetBookingDataById(postCreatedBooking.Bookingid);
            
            //Check if getResponse is not null
            Assert.IsNotNull(getResponse);

            var getCreatedBooking = JsonConvert.DeserializeObject<Booking>(getResponse.Content.ReadAsStringAsync().Result);   
            
            //Assertion
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode, "Status code is not equal to 201");
            Assert.AreEqual(getCreatedBooking.Firstname, postCreatedBooking.Booking.Firstname, "First Name is not matching.");
            Assert.AreEqual(getCreatedBooking.Lastname, postCreatedBooking.Booking.Lastname, "Last Name is not matching.");
            Assert.AreEqual(getCreatedBooking.Totalprice, postCreatedBooking.Booking.Totalprice, "Total price is not matching.");
            Assert.AreEqual(getCreatedBooking.Additionalneeds, postCreatedBooking.Booking.Additionalneeds, "Additional needs is not matching.");
            Assert.AreEqual(getCreatedBooking.Bookingdates.Checkin, postCreatedBooking.Booking.Bookingdates.Checkin, "Check in date is not matching.");
            Assert.AreEqual(getCreatedBooking.Bookingdates.Checkout, postCreatedBooking.Booking.Bookingdates.Checkout, "Check out date is not matching.");                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

            //Cleanup
            var deleteRequest = await BookingHelpers.DeleteBookingDataById(postCreatedBooking.Bookingid);
            Assert.AreEqual(HttpStatusCode.Created, deleteRequest.StatusCode, "Status code is not equal to 201");
        }

        [TestMethod]
        public async Task UpdateFirstandLastnameDetails()
        {
            //creating object and sending put request
            var postResponse = await BookingHelpers.CreateNewBookingData();
            var postCreatedBooking = JsonConvert.DeserializeObject<BookingModels>(postResponse.Content.ReadAsStringAsync().Result);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

            //booking object initialize 
            Booking bookingUpdate = new Booking()
            {
                Firstname = "Justin-Edit",
                Lastname = "Salazar-Edit",
                Totalprice = 99999,
                Depositpaid = true,
                Bookingdates = new Bookingdates()
                {
                    Checkin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                    Checkout = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))
                },
                Additionalneeds = "More and More COFFEE"
            };

            //Act
            var putResponse = await BookingHelpers.UpdateBookingDataById(postCreatedBooking.Bookingid, bookingUpdate);
            var updatedBookingData = JsonConvert.DeserializeObject<Booking>(putResponse.Content.ReadAsStringAsync().Result);

            //Assertion
            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode, "Status code is not equal to 201");
            Assert.AreEqual(updatedBookingData.Firstname, bookingUpdate.Firstname, "First Name is not matching.");
            Assert.AreEqual(updatedBookingData.Lastname, bookingUpdate.Lastname, "Last Name is not matching.");
            Assert.AreEqual(updatedBookingData.Totalprice, bookingUpdate.Totalprice, "Total price is not matching.");
            Assert.AreEqual(updatedBookingData.Additionalneeds, bookingUpdate.Additionalneeds, "Additional needs is not matching.");
            Assert.AreEqual(updatedBookingData.Bookingdates.Checkin, postCreatedBooking.Booking.Bookingdates.Checkin, "Check in date is not matching.");
            Assert.AreEqual(updatedBookingData.Bookingdates.Checkout, postCreatedBooking.Booking.Bookingdates.Checkout, "Check out date is not matching.");                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

            //Cleanup
            var deleteRequest = await BookingHelpers.DeleteBookingDataById(postCreatedBooking.Bookingid);
            Assert.AreEqual(HttpStatusCode.Created, deleteRequest.StatusCode, "Status code is not equal to 201");

        }

        [TestMethod]
        public async Task DeleteBookingInformation() 
        {   
            //Creating a new booking data
            var postResponse = await BookingHelpers.CreateNewBookingData();
            var postCreatedBooking = JsonConvert.DeserializeObject<BookingModels>(postResponse.Content.ReadAsStringAsync().Result);
            
            //Act
            var deleteResponse = await BookingHelpers.DeleteBookingDataById(postCreatedBooking.Bookingid);
           
            //Assertion
            Assert.AreEqual(HttpStatusCode.Created, deleteResponse.StatusCode, "Status code is not equal to 201");
            
        }

        [TestMethod]
        public async Task GetInvalidBookingViaId()
        {
            //creation of invalid data and sending request
            var InvalidCode = "696969696969696969";
            var postResponse = await BookingHelpers.CreateNewBookingData();
            var postCreatedBooking = JsonConvert.DeserializeObject<BookingModels>(postResponse.Content.ReadAsStringAsync().Result);
            
            //Act
            var getResponse = await BookingHelpers.GetBookingDataById((long)Convert.ToDouble(InvalidCode));
            
            //Assertion
            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode, "Status code is not equal to 404");

            //Cleanup
            var deleteRequest = await BookingHelpers.DeleteBookingDataById(postCreatedBooking.Bookingid);
            Assert.AreEqual(HttpStatusCode.Created, deleteRequest.StatusCode, "Status code is not equal to 201");

        }
    }
}
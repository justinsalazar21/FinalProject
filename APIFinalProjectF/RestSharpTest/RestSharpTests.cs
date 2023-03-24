using RestSharp;
using RestSharpTest.DataModels;                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
using RestSharpTest.Helpers;
using System.Net;


namespace RestSharpTest.Tests
{
    [TestClass]
    public class RestSharpTests : RESTtest
    {
        [TestMethod]
        public async Task CreateNewBookingDetails()
        {
            //Creating and retrieving new booking data
            var postReponse = await BookingHelpers.CreateNewBookingData(RestClient);
            var getReponse = await BookingHelpers.GetBookById(RestClient, postReponse.Data.Bookingid);

            //passing values from the retrieved data
            var createdBookingData = postReponse.Data;
            var retrievedBookingData = getReponse.Data;

            //Assertion
            Assert.AreEqual(HttpStatusCode.OK, postReponse.StatusCode, "Status code is not equal to 201");
            Assert.AreEqual(createdBookingData.Booking.Firstname, retrievedBookingData.Firstname, "First Name is not matching.");
            Assert.AreEqual(createdBookingData.Booking.Lastname, retrievedBookingData.Lastname, "Last Name is not matching.");
            Assert.AreEqual(createdBookingData.Booking.Totalprice, retrievedBookingData.Totalprice, "Total Price is not matching.");
            Assert.AreEqual(createdBookingData.Booking.Depositpaid, retrievedBookingData.Depositpaid, "Deposit Paid is not matching.");
            Assert.AreEqual(createdBookingData.Booking.Bookingdates.Checkin, retrievedBookingData.Bookingdates.Checkin, "Checkin date is not matching.");                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
            Assert.AreEqual(createdBookingData.Booking.Bookingdates.Checkout, retrievedBookingData.Bookingdates.Checkout, "Checkout date is not matching.");
            Assert.AreEqual(createdBookingData.Booking.Additionalneeds, retrievedBookingData.Additionalneeds, "Additional needs is not matching.");

            //Cleanup
            var deleteRequest = await BookingHelpers.DeleteBookingData(RestClient, createdBookingData.Bookingid);
            Assert.AreEqual(HttpStatusCode.Created, deleteRequest.StatusCode, "Status code is not equal to 201");

        }

        [TestMethod]
        public async Task UpdateFirstandLastnameDetails()
        {
            //create data and send put request
            var postResponse = await BookingHelpers.CreateNewBookingData(RestClient);
            var postCreatedBooking = postResponse.Data;

            //object creation for put
            Booking booking = new Booking()
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
            var putResponse = await BookingHelpers.UpdateBookingData(RestClient, postCreatedBooking.Bookingid, booking);
            //passing putresponse data
            var updatedBookingData = putResponse.Data;

            //Assertion
            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode, "Status code is not equal to 201");
            Assert.AreEqual(updatedBookingData.Firstname, booking.Firstname, "First Name is not matching.");
            Assert.AreEqual(updatedBookingData.Lastname, booking.Lastname, "Last Name is not matching.");
            Assert.AreEqual(updatedBookingData.Totalprice, booking.Totalprice, "Total price is not matching.");
            Assert.AreEqual(updatedBookingData.Additionalneeds, booking.Additionalneeds, "Additional needs is not matching.");
            Assert.AreEqual(updatedBookingData.Bookingdates.Checkin, postCreatedBooking.Booking.Bookingdates.Checkin, "Check in date is not matching.");
            Assert.AreEqual(updatedBookingData.Bookingdates.Checkout, postCreatedBooking.Booking.Bookingdates.Checkout, "Check out date is not matching.");
            

            //Cleanup
            var deleteRequest = await BookingHelpers.DeleteBookingData(RestClient, postCreatedBooking.Bookingid);
            Assert.AreEqual(HttpStatusCode.Created, deleteRequest.StatusCode, "Status code is not equal to 201");
            
        }

        [TestMethod]
        public async Task DeleteBookingInformation()
        {
            //Creating a new booking data
            var postResponse = await BookingHelpers.CreateNewBookingData(RestClient);
            var postCreatedBooking = postResponse.Data;

            //Act
            var deleteResponse = await BookingHelpers.DeleteBookingData(RestClient, postCreatedBooking.Bookingid);

            //Assertion
            Assert.AreEqual(HttpStatusCode.Created, deleteResponse.StatusCode, "Status code is not equal to 201");
            
        }

        [TestMethod]
        public async Task GetInvalidBookingViaId()
        {
            //creation of invalid data and sending request
            var InvalidCode = "696969696969696969";
            var postResponse = await BookingHelpers.CreateNewBookingData(RestClient);
            var postCreatedBooking = postResponse.Data;
            
            //Act
            var getResponse = await BookingHelpers.GetBookById(RestClient, (long)Convert.ToDouble(InvalidCode));

            //Assertion
            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode, "Status code is not equal to 404");

            //Cleanup
            var deleteRequest = await BookingHelpers.DeleteBookingData(RestClient, postCreatedBooking.Bookingid);                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
            Assert.AreEqual(HttpStatusCode.Created, deleteRequest.StatusCode, "Status code is not equal to 201");
        }
    }
}
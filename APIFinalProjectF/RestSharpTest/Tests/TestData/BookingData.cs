using RestSharpTest.DataModels;

namespace RestSharpTest.Tests.TestData                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
{
    public class BookingData
    {
        public static Booking demoBooking()
        {
            return new Booking
            {
                Firstname = "Justin",
                Lastname = "Salazar",
                Totalprice = 10000,
                Depositpaid = true,
                Bookingdates = new Bookingdates()
                {
                    Checkin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
                    Checkout = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))
                },
                Additionalneeds = "Coffee, More Coffee"
            };
        }
    }
    
}

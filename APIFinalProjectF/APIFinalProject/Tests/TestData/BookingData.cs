using HttpClientTest.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTest.Tests.TestData
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
                Bookingdates = new Bookingdates(){
                    Checkin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                    Checkout = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
                },
                Additionalneeds = "Coffee, More Coffee"
            };
        }
    }
}

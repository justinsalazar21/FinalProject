using Newtonsoft.Json;

namespace HttpClientTest.DataModels
{
    public partial class BookingModels
    {
        [JsonProperty("bookingid")]
        public long Bookingid { get; set; }                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023

        [JsonProperty("booking")]
        public Booking Booking { get; set; }
    }
    public partial class Booking
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("totalprice")]
        public long Totalprice { get; set; }

        [JsonProperty("depositpaid")]
        public bool Depositpaid { get; set; }

        [JsonProperty("bookingdates")]
        public Bookingdates Bookingdates { get; set; }

        [JsonProperty("additionalneeds")]
        public string Additionalneeds { get; set; }
    }
    public partial class Bookingdates
    {
        [JsonProperty("checkin")]
        public DateTimeOffset Checkin { get; set; }

        [JsonProperty("checkout")]
        public DateTimeOffset Checkout { get; set; }                                                                                                                                                                                                                                                                                                                                                                              //created by justin salazar 3/23/2023
    }

}

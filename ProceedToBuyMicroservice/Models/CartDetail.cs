using System;

namespace ProceedToBuyMicroservice.Models
{
    public class CartDetail
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Zipcode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Vendor VendorObj { get; set; }
    }
}

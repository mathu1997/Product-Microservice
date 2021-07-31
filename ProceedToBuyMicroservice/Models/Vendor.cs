using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyMicroservice.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public float Rating { get; set; }
        public decimal DeliveryCharge { get; set; }
    }
}

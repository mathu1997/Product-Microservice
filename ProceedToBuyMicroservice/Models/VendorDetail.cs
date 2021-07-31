using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyMicroservice.Models
{
    public class VendorDetail
    {
        public int vendorId { get; set; }
        public string vendorName { get; set; }
        public float rating { get; set; }
        public decimal deliveryCharge { get; set; }
    }
}

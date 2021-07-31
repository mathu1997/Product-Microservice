using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorMicroservice.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public int DeliveryCharge { get; set; } 
        public float Rating { get; set; }

    }
}

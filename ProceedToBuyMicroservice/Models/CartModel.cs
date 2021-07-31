using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyMicroservice.Models
{
    public class CartModel
    {
        public int Product_Id { get; set; }
        public int Customer_Id { get; set; }       
        public int Zipcode { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}

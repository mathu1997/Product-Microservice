using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyMicroservice.Models
{
    public class WishlistDetail
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAddedToWishlist { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorMicroservice.Models
{
    public class VendorStock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public int StockInHand { get; set; }
        public DateTime ReplinshmentDate { get; set; }
    }
}

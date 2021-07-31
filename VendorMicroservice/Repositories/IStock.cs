using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;

namespace VendorMicroservice.Repositories
{
    public interface IStock
    {
        public int Index(int id);
        public int Index(VendorStock stock);
        public int Length();
        public List<VendorStock> Get();
        public VendorStock Get(int id);
        public VendorStock GetStock(int ProductId);
        public bool Put(int id, VendorStock stock);
        public bool Post(VendorStock stock);
        public bool Delete(int id);
    }
}

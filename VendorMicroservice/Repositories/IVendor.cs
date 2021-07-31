using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;

namespace VendorMicroservice.Repositories
{
    public interface IVendor
    {
        public int Index(int id);
        public int Index(Vendor vendor);
        public int Length();
        public List<Vendor> Get();
        public Vendor Get(int id);
        public bool Put(int id, Vendor vendor);
        public bool Post(Vendor vendor);
        public bool Delete(int id);
    }
}

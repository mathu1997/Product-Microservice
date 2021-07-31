using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;

namespace VendorMicroservice.Repositories
{
    public class MockRepository:IVendor
    {
        private static List<Vendor> vendors = new List<Vendor>()
        {
                new Vendor { VendorId = 1, Name = "Apple Store",  DeliveryCharge= 300,Rating = 8.8f },
                new Vendor { VendorId = 2, Name = "Sunil Traders", DeliveryCharge = 100, Rating = 8.2f },
                new Vendor { VendorId = 3, Name = "Samsung", DeliveryCharge = 150, Rating = 9.2f },
                new Vendor { VendorId = 4, Name = "LogiTech", DeliveryCharge= 150, Rating = 5.2f },
                new Vendor { VendorId = 5, Name = "Redmi stores", DeliveryCharge = 200, Rating = 4 },
        };
        public int Index(int id) => Index(Get(id));

        public int Index(Vendor vendor) => vendors.IndexOf(vendor);

        public int Length() => vendors.Count();

        public List<Vendor> Get() => vendors;

        public Vendor Get(int id) => (Vendor)vendors.Where(v => v.VendorId == id).FirstOrDefault();

        public bool Put(int id, Vendor vendor)
        {
            vendors[Index(id)] = vendor;
            return true;
        }

        public bool Post(Vendor vendor)
        {
            vendors.Add(vendor);
            return true;
        }

        public bool Delete(int id)
        {
            vendors.RemoveAt(Index(id));
            return true;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;

namespace VendorMicroservice.Repositories
{
    public class MockStockRepository : IStock
    {
        private static List<VendorStock> stocks = new List<VendorStock>() {
             //new VendorStock{StockId=2,VendorId=1,ProductId=2,StockInHand=50,} ,
             //new VendorStock{StockId=3,VendorId=2,ProductId=3,StockInHand=0,
             //   ReplinshmentDate=DateTime.Now.AddDays(new Random().Next(1,6)),} ,
             new VendorStock {ProductId = 1, VendorId = 4,StockInHand=1, },
                new VendorStock {ProductId = 2, VendorId = 1,StockInHand=1},
                new VendorStock {ProductId = 3, VendorId = 5,StockInHand=1},
                new VendorStock {ProductId = 4, VendorId = 4,StockInHand=1},
                new VendorStock {ProductId = 5, VendorId = 1,StockInHand=1},
                new VendorStock {ProductId = 6, VendorId = 1,StockInHand=0,ReplinshmentDate=DateTime.Now.AddDays(new Random().Next(1,6))},
                new VendorStock {ProductId = 7, VendorId = 2,StockInHand=1},
                new VendorStock {ProductId = 8, VendorId = 1,StockInHand=1},
                new VendorStock {ProductId = 9, VendorId = 5,StockInHand=0,ReplinshmentDate=DateTime.Now.AddDays(new Random().Next(1,6))},
                new VendorStock {ProductId= 10, VendorId = 3,StockInHand=1},
        };
        public bool Delete(int id)
        {
            stocks.RemoveAt(Index(id));
            return true;
        }

        public List<VendorStock> Get() => stocks;

        public VendorStock Get(int stockid) => (VendorStock)Get().Where(stock => stock.StockId == stockid);

        public VendorStock GetStock(int ProductId) => (VendorStock)Get().Where(stock => stock.ProductId == ProductId).FirstOrDefault();
        
        public int Index(int id) => Index(Get(id));

        public int Index(VendorStock stock) => Get().IndexOf(stock);

        public int Length() => Get().Count();

        public bool Post(VendorStock stock)
        {
            stocks.Add(stock);
            return true;
        }

        public bool Put(int id, VendorStock stock)
        {
            stocks[Index(id)] = stock;
            return true;
        }
    }
}

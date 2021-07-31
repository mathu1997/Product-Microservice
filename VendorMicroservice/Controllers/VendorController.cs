using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;
using VendorMicroservice.Repositories;

namespace VendorMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendor vendorRepo;
        private readonly IStock stockRepo;

        public VendorController(IVendor vendorRepo, IStock stockRepo)
        {
            this.vendorRepo = vendorRepo;
            this.stockRepo = stockRepo;
        }

        [HttpGet]
        public ActionResult GetVendorDetails() => Ok(vendorRepo.Get());
        [HttpGet("id={ProductId}")]
        public ActionResult GetVendorDetails(int ProductId){
            VendorStock stock = stockRepo.GetStock(ProductId);
            return Ok(vendorRepo.Get(stock.VendorId));

        }
        [HttpGet("stocks")]
        public ActionResult GetStockDetails() => Ok(stockRepo.Get());

        [HttpGet("stocks/id={ProductId}")]
        public ActionResult GetStockDetails(int ProductId) => Ok(stockRepo.GetStock(ProductId));
    }
}

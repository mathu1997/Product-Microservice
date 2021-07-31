using Microsoft.AspNetCore.Mvc;
using product_management_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productrepo;
        public ProductController(IProduct product)
        {
            this.productrepo = product;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetProduct() => productrepo.Get();

        [HttpGet("id={ProductId}")]
        public Product SearchProductById(int ProductId) => productrepo.Get(ProductId);

        [HttpGet("name={ProductName}")]
        public IEnumerable<Product> SearchProductByName(string ProductName) => productrepo.GetByName(ProductName);
        
        [HttpPost("update")]
        public ActionResult AddProductRating(int ProductId,float Rating)
        {
            Product product = productrepo.Get(ProductId);
            if(product==null)
                return BadRequest("Please check product id, " + ProductId + " is not valid id");
            product.Rating = Rating;
            if (productrepo.Put(ProductId, product)){
                return Ok(product);
            }
            return BadRequest("Please check product id, "+ProductId+" is not valid id");
        }
        
       
    }
}

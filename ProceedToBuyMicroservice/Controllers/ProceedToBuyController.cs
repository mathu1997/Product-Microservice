using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProceedToBuyMicroservice.Models;
using ProceedToBuyMicroservice.Repository;
using ProceedToBuyMicroservice.Services;

namespace ProceedToBuyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceedToBuyController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyController));
        private readonly IProceedToBuyService _provider;
        private readonly IProceedToBuyRepository _cart;
        public ProceedToBuyController(IProceedToBuyService cartdetails, IProceedToBuyRepository cart)
        {
            this._provider = cartdetails;
            this._cart = cart;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cart.Get());
        }
        [HttpGet("id={cartid}")]
        public IActionResult Get(int cartid)
        {
            return Ok(_cart.Get(cartid));
        }
        [HttpGet("wishlist")]
        public IActionResult Getwishlist()
        {
            return Ok(_cart.GetWishList());
        }
        // POST: api/AddToCart
        [HttpPost]
        [Route("AddToCart")]
        public IActionResult AddToCart([FromBody] CartModel cart)
        {
            _log4net.Info("Add to Cart method initiated");
            try
            {
                CartDetail newcart = new CartDetail()
                {
                    CartId = _cart.length()+1,
                    CustomerId = cart.Customer_Id,
                    ProductId = cart.Product_Id,
                    DeliveryDate = cart.DeliveryDate,
                    Zipcode = cart.Zipcode
                };
                CartDetail result = _cart.addToCart(newcart);
                if (result == null)
                {
                    return BadRequest();
                }
                _log4net.Info("Added to Cart");
                return Ok(result);
            }
            catch
            {
                _log4net.Info("Cannot Add To Cart");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("AddToWishlist")]
        public IActionResult AddToWishList([FromBody] WishlistDetail wish)
        {
            _log4net.Info("Add to WishList method initiated");
            try
            {
                _log4net.Info("Add To Wishlist Provider called");
                return Ok(_cart.addToWishlist(wish));

            }
            catch
            {
                _log4net.Info("Error calling Add Wishlist provider");
                return BadRequest();
            }
        }
    }
}

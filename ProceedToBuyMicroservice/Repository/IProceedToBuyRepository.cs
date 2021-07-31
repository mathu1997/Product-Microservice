using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProceedToBuyMicroservice.Models;

namespace ProceedToBuyMicroservice.Repository
{
    public interface IProceedToBuyRepository
    {
        public List<Cart> Get();
        public Cart Get(int cartid);
        public List<Wishlist> GetWishList();
        public int length();
        public WishlistDetail addToWishlist(WishlistDetail entity);
        public CartDetail addToCart(CartDetail entity);
    }
}

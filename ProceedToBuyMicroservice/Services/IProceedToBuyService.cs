using System;
using ProceedToBuyMicroservice.Models;

namespace ProceedToBuyMicroservice.Services
{
    public interface IProceedToBuyService
    {
        public CartDetail GetSupply(int prodid,int cutsid,int zipcode,DateTime delidt);
        public WishlistSuccess Wish(int custid, int prodid);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ProceedToBuyMicroservice.Models;
using ProceedToBuyMicroservice.Repository;

namespace ProceedToBuyMicroservice.Services
{
    public class ProceedToBuyServices : IProceedToBuyService
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyServices));
        private readonly IProceedToBuyRepository proceedToBuyRepository;
        public ProceedToBuyServices(IProceedToBuyRepository repo)
        {
            proceedToBuyRepository = repo;
        }
        public WishlistSuccess Wish(int custid,int prodid)
        {
            
            WishlistDetail wl = new WishlistDetail()
            {               
                CustomerId=custid,
                ProductId = prodid,
                Quantity=1,
                DateAddedToWishlist=DateTime.Now.Date
            };
            WishlistDetail wl1 = proceedToBuyRepository.addToWishlist(wl);
            WishlistSuccess msg = new WishlistSuccess();
            if (wl1 != null)
            {
                msg.Message = " Product added to wishlist";
                return msg;
            }

            return null;
        }
       

        public CartDetail GetSupply(int prodid,int custid,int zipcode,DateTime delidt)
        {

            var client = new HttpClient();
             client.BaseAddress = new Uri("http://localhost:52121/");
            // client.BaseAddress = new Uri("http://52.224.36.210/");
            client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/GetVendorDetails/"+prodid).Result;
                
                   // string apiResponse =  response.Content.ReadAsStringAsync().Result;
                   var value = response.Content.ReadAsStringAsync().Result;

                    List<VendorDetail> vendorsdto = JsonConvert.DeserializeObject<List<VendorDetail>>(value);
            if(vendorsdto.Count > 0)
            {
                float max = 0;
                VendorDetail taggeddto = vendorsdto.FirstOrDefault();

                foreach (VendorDetail v in vendorsdto)
                {
                    if (v.rating >= max)
                    {
                        max = v.rating;
                        taggeddto = v;
                    }
                }
                Vendor taggedvendor = new Vendor()
                {
                    VendorId = taggeddto.vendorId,
                    VendorName = taggeddto.vendorName,
                    Rating = taggeddto.rating,
                    DeliveryCharge = taggeddto.deliveryCharge
                };
                
               
               
                    Random unid = new Random();
                    CartDetail finalcart = new CartDetail()
                    {
                        CartId = unid.Next(1, 999),
                        CustomerId = custid,
                        ProductId = prodid,
                        Zipcode = zipcode,
                        DeliveryDate = delidt,
                        VendorObj = taggedvendor,
                    };
                    CartDetail ficart = proceedToBuyRepository.addToCart(finalcart);
                    return finalcart;               
            }
            else
            {
                CartDetail fcart = new CartDetail();
                fcart.ProductId = prodid;
                fcart.CustomerId = custid;
                fcart.Zipcode = zipcode;
                return fcart;
                
            }

        }
    }
}

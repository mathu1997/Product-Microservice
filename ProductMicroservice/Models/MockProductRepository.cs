using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;


namespace product_management_project.Models
{
    public class MockProductRepository:IProduct
    {
        private static List<Product> ProductData = new List<Product>()
            {
                new Product(Id:1,Price:1500,Name:"Cosmic Byte headphones",Description:"Giving you next level gaming experience",ImageName:"../assets/Images/CosmicByteHeadphones.jpeg",Rating:4),
                new Product(Id:2,Price:120000,Name:"IPhone 12 Pro Max",Description:"A very beautiful and elegant device",ImageName:"https://img.phonandroid.com/2020/06/concept-iphone-douze.jpg",Rating:5),
                new Product(Id:3,Price:15000,Name:"Poco F1",Description:"The beast in your pocket",ImageName:"https://zeedong.com/wp-content/uploads/2021/04/ggg-1.jpg",Rating:3),
                new Product(Id:4,Price:2000,Name:"Bluetooth Mouse",Description:"Keep conncted without connection",ImageName:"https://m.media-amazon.com/images/I/81hcEqMZEFL._AC_SL1500_.jpg",Rating:4),
                new Product(Id:5,Price:150000,Name:"Mac book pro",Description:"Secure like never before",ImageName:"https://cdn.ndtv.com/tech/images/gadgets/macbook_air_apple_official_site.jpg",Rating:5),
                new Product(Id:6,Price:20000,Name:"Air pods",Description:"No delay. Music at its best",ImageName:"https://icdn.digitaltrends.com/image/digitaltrends/apple-airpods-pro-press-release-1080.jpg",Rating:4),
                new Product(Id:7,Price:5000,Name:"Hard Disk",Description:"Refined designed with massive capacity",ImageName:"https://www.estufs.com/wp-content/uploads/2017/10/Seagate-announces-gigantic-hard-disk-drive-Barracuda-for-storage-of-4k-videos.jpg",Rating:5),
                new Product(Id:8,Price:40000,Name:"Apple watch",Description:"Advanced Technology in your hand",ImageName:"https://images-na.ssl-images-amazon.com/images/I/61VUa2A6%2BsS._AC_SX522_.jpg",Rating:4),
                new Product(Id:9,Price:50000,Name:"Tablet",Description:"Everything in one!!",ImageName:"https://i.pinimg.com/originals/7f/0a/55/7f0a55a7eefbcddd537966b6f6b38236.jpg",Rating:5),
                new Product(Id:10,Price:80000,Name:"Smart Tv",Description:"Big Screen new Experience",ImageName:"https://images.jdmagicbox.com/quickquotes/images_main/kevin-kn55uhd-139-7-cm-55-4k-ultra-hd-smart-led-tv-black-106489503-db6so.jpg",Rating:4)
            };

        public bool Delete(int id)
        {
            try
            {
                Product product = Get(id);
                if (product != null)
                {
                    int index = ProductData.IndexOf(product);
                    ProductData.RemoveAt(index);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Product> Get()
        {
            return ProductData;
        }

        public Product Get(int id)
        {
            return ProductData.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetByName(string Name)
        {
            return ProductData.Where(p => p.Name.Contains(Name));
        }

        public IEnumerable<Product> GetByRating(float Rating)
        {
            return ProductData.Where(p => p.Rating==Rating);
        }

        public bool Post(Product NewProduct)
        {
            try
            {
                ProductData.Add(NewProduct);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Put(int id, Product ChangeProduct)
        {
            Product product = Get(id);
            if (product != null)
            {
                
                int index = ProductData.IndexOf(product);
                ProductData[index] = ChangeProduct;
                return true;
            }
            return false;
        }
    }
   
}

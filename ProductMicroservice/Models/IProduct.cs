using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_management_project.Models
{
    public interface IProduct
    {
        public IEnumerable<Product> Get();
        public Product Get(int id);
        public IEnumerable<Product> GetByName(string Name);
        public IEnumerable<Product> GetByRating(float Rating);
        public bool Post(Product NewProduct);
        public bool Put(int id,Product ChangeProduct);
        public bool Delete(int id);
        
    }
}

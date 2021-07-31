using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace product_management_project.Models
{
    public class Product
    {
        public Product(int Id,int Price,string Name,string Description="",string ImageName = "",float Rating=0)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.Rating = Rating;
            this.ImageName = ImageName;
        }   
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public float Rating { get; set; }
    }
}

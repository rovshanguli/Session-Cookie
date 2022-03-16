using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWork_MigrationLesson.Models
{
    public class Product : BaseEntity
    { 
        public string  Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}

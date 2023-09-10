using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoMarket.DAL.Entities
{
    public class Product : TimeStample
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Comment
    {

        public int Id { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}

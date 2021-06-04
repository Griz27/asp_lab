using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ShopDbInitializer
    {
        public static void Initialize(ShopDbContext context)
        {
            if (!context.Categories.Any())
            {
                Category category1 = new Category { Name = "Телефоны" };
                context.Categories.Add(category1);
                Product product1 = new Product { Title = "One Plus 3", Category = category1, Price = 25999 };
                Product product2 = new Product { Title = "iPhone 12pro", Category = category1, Price = 15999 };
                context.Products.AddRange(product1, product2);
                User user = new User { Login = "Admin", Email = "ruban@gmail.com", Password = "1111" };
                context.Users.Add(user);
                Comment comment1 = new Comment { Text = "Качественный телефон!", Product = product1, User = user };
                Comment comment2 = new Comment { Text = "Остался не доволен!!!", Product = product2, User = user };
                context.Comments.AddRange(comment1, comment2);
                context.SaveChanges();
            }
        }
    }
}

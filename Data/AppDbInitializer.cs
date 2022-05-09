using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "The City Of Owls",
                        Genre = "Thriller",
                        Description = "The first of the owls series",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 1,
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    }, new Book()
                    {
                        Title = "Calamite Lotion",
                        Genre = "Romance",
                        Description = "An intrigueing love story",
                        IsRead = false,
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

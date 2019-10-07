using System;
using System.Threading.Tasks;
using Core;
using Core.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

              var contextOptions = new DbContextOptionsBuilder<AppDbContext>();
            contextOptions.UseCosmos("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "CosmosTest");
            var appDbContext = new AppDbContext(contextOptions.Options);

            var item = CreateItem();

            var result = await appDbContext.Items.AddAsync(item);
            await appDbContext.SaveChangesAsync();

            var r = await appDbContext.Items.FirstOrDefaultAsync();
        }

        static Item CreateItem(){
            return new Item
            {
                Id = Guid.NewGuid().ToString(),
                Images = new ItemImage[]
                {
                new ItemImage
                {
                    Id = Guid.NewGuid().ToString(),
                    ImageUrl = "www.google.com",
                    Attributes = new ImageAttribute[]
                    {
                    new ImageAttribute
                    {
                        Content = "Green"
                    },
                    new ImageAttribute
                    {
                        Content = "Ocean"
                    },
                    }
                },
                new ItemImage
                {
                    Id = Guid.NewGuid().ToString(),
                    ImageUrl = "www.dotnetconf.com",
                    Attributes = new ImageAttribute[]
                    {
                    new ImageAttribute
                    {
                        Content = "Purple"
                    },
                    new ImageAttribute
                    {
                        Content = "Video"
                    },
                    }
                }
                }
            };
        }
    }
}

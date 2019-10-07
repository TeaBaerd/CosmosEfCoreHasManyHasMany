using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationDbContext
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {
      var created = Database.EnsureCreatedAsync().Result;
    }

    public DbSet<Item> Items { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var products = modelBuilder.Entity<Item>().ToContainer("Items");
      products.OwnsMany<ItemImage>(x => x.Images, b => 
      {
        b.OwnsMany<ImageAttribute>(x => x.Attributes);
      });

      //also fails
      //products.OwnsMany(x => x.Images).OwnsMany(x => x.Attributes);
    }
  }
}

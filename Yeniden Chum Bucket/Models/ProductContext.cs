using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Yeniden_Chum_Bucket.Models;

namespace Yeniden_Chum_Bucket.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("Server=LAPTOP-M2LJ0R6T;Database=StoreDB;Trusted_Connection=True;")
        {

        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>();


        }
    }
}
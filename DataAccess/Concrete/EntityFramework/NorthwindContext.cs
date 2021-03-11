using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: DB tabloları ile proje classlarını bağlamak
    public class NorthwindContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\mssqllocaldb; Database = Northwind; Trusted_Connection = true");
        }

        public DbSet<Product> Products { get; set; } // benim Product nesnemi, veritabanındaki Products ile bağla
        public DbSet<Category> Categories { get; set; } // benim Category nesnemi, veritabanındaki Cateories ile bağla
        public DbSet<Customer> Customers { get; set; } // benim Customer nesnemi, veritabanındaki Customers ile bağla
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}

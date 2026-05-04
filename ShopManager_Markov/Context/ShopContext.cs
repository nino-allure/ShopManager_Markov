using Microsoft.EntityFrameworkCore;
using ShopManager_Markov.Classes.Database;
using ShopManager_Markov.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManager_Markov.Context
{
    public class ClientsContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ClientsContext()
        {
            Database.EnsureCreated();
            Clients.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, Config.version);
        }
    }

    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext()
        {
            Database.EnsureCreated();
            Products.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, Config.version);
        }
    }
}

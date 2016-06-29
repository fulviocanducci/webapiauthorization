﻿using System.Configuration;
using System.Data.Entity;
namespace WebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : 
            base("BaseWebApiConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Credit> Credits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(UserConfiguration.Create());
            modelBuilder.Configurations.Add(CreditConfiguration.Create());
        }
    }
}
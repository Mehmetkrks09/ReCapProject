using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramwork
{
  public  class context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\ProjectsV13;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Car> Car { get; set; }
        //public DbSet<Order> orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        //public DbSet<Customers> Customer { get; set; }
    }
}

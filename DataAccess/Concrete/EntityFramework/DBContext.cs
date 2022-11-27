using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //@ koyduğumuzda kaçış dizisi yapmamıza gerek kalmaz \ ı string olarak algılar @ koymazsak \\ yapmamız gerekir.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=RentACarDB;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rentals> Rentals { get; set; }

    }
}

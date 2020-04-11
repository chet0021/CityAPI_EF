using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
    public class MayorContext : DbContext
    {
        public DbSet<Mayor> Mayor { get; set; }
        public DbSet<City> City { get; set; }
        public MayorContext(DbContextOptions<MayorContext> options)
           : base(options)
        {
            //  Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mayor>()
                 .HasData(
                new Mayor()
                {
                    Id = 1,
                    Name = "Vico Sotto",
                    Age = 40,
                },
                new Mayor()
                {
                    Id = 2,
                    Name = "Isko Moreno",
                    Age = 45,
                },
                new Mayor()
                {
                    Id = 3,
                    Name = "Menchie Abalos",
                    Age = 42,
                });
            modelBuilder.Entity<City>()
              .HasData(
                    new City()
                    {
                        Id = 1,
                        Name = "Pasig City",
                        Description = "Business center in the North",
                    },
                new City()
                {
                    Id = 2,
                    Name = "Makati City",
                    Description = "Shopping capital",
                },
                new City()
                {
                    Id = 3,
                    Name = "Manila",
                    Description = "Capital of the Philippines",
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}

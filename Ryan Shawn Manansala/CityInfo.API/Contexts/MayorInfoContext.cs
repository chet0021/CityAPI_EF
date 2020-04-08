
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
    public class MayorInfoContext : DbContext
    {
        public DbSet<Mayor> Mayor { get; set; }

        public MayorInfoContext(DbContextOptions<MayorInfoContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mayor>()
                 .HasData(
                new Mayor()
                {
                    Id = 1,
                    Name = "Isko Moreno",
                    Age = 45
                },
                new Mayor()
                {
                    Id = 2,
                    Name = "Francis Zamora",
                    Age = 42
                }
                );

        }
    }
}

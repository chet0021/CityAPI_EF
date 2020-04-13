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
        public DbSet<Mayor> MayorDTO { get; set; }

        public MayorInfoContext(DbContextOptions<MayorInfoContext> options)
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
                    Age = 30
                },
                new Mayor()
                {
                    Id = 2,
                    Name = "Isko Moreno",
                    Age = 44
                },
                new Mayor()
                {
                    Id = 3,
                    Name = "Abigail Binay",
                    Age = 40
                }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}

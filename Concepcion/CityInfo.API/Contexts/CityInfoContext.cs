using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
	public class CityInfoContext : DbContext
	{
		public DbSet<City> City { get; set; }
		public DbSet<PointOfInterest> PointsOfInterest { get; set; }
		public DbSet<Mayor> Mayor { get; set; }
		public CityInfoContext(DbContextOptions<CityInfoContext> options)
		   : base(options)
		{
			//  Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
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
				});


			modelBuilder.Entity<PointOfInterest>()
			  .HasData(
				new PointOfInterest()
				{
					Id = 1,
					CityId = 1,
					Name = "Ortigas Center",
					Description = "central business district located within the joint boundaries of Pasig, Mandaluyong and Quezon City"

				},
				new PointOfInterest()
				{
					Id = 2,
					CityId = 1,
					Name = "Pasig River",
					Description = "The Pasig River is a river in the Philippines that connects Laguna de Bay to Manila Bay"
				},
				  new PointOfInterest()
				  {
					  Id = 3,
					  CityId = 2,
					  Name = "Greenbelt",
					  Description = "Greenbelt is a shopping mall located at Ayala Center"
				  },
				new PointOfInterest()
				{
					Id = 4,
					CityId = 3,
					Name = "Divisoria",
					Description = "Cheap bargains"
				},
				new PointOfInterest()
				{
					Id = 5,
					CityId = 3,
					Name = "Binondo",
					Description = "Chinese people"
				},
				new PointOfInterest()
				{
					Id = 6,
					CityId = 3,
					Name = "Rizal Park",
					Description = "Park of Rizal"
				}
				);

			modelBuilder.Entity<Mayor>()
				 .HasData(
				new Mayor()
				{
					Id = 1,
					Name = "Isko Moreno",
					Age = 45,
					Nickname = "Yorme"
				},
				new Mayor()
				{
					Id = 2,
					Name = "Vicco Sotto",
					Age = 45,
					Nickname = "Vivico"
				},
				new Mayor()
				{
					Id = 3,
					Name = "Marcy Teodoro",
					Age = 44,
					Nickname = "Marcy"
				});

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CityInfo");
		}

	}
}

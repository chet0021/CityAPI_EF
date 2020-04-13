using MayorInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MayorInfo.API.Models;

namespace MayorInfo.API.Contexts
{
	public class MayorInfoContext : DbContext
	{
		public DbSet<Mayor> Mayor { get; set; }
		
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
					Name = "Mar Serrano",
					Age = 41,
					Gender = "M"

				},
				new Mayor()
				{
					Id = 2,
					Name = "Bren Loria",
					Age = 42,
					Gender = "M"
				}
				
			);

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<MayorInfo.API.Models.MayorDto> MayorDto { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//    optionsBuilder.UseSqlServer("connectionstring");
		//    base.OnConfiguring(optionsBuilder);
		//}

	}
}

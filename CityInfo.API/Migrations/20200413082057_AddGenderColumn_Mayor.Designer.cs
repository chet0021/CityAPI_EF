﻿// <auto-generated />
using System;
using CityInfo.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20200413082057_AddGenderColumn_Mayor")]
    partial class AddGenderColumn_Mayor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<int?>("MayorId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("MayorId");

                    b.ToTable("City");

                    b.HasData(
                        new { Id = 1, Description = "Business center in the North", Name = "Pasig City" },
                        new { Id = 2, Description = "Shopping capital", Name = "Makati City" },
                        new { Id = 3, Description = "Capital of the Philippines", Name = "Manila" }
                    );
                });

            modelBuilder.Entity("CityInfo.API.Entities.Mayor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Gender")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Mayor");
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<int>("CityId");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterest");

                    b.HasData(
                        new { Id = 1, CityId = 1, Description = "central business district located within the joint boundaries of Pasig, Mandaluyong and Quezon City", Name = "Ortigas Center" },
                        new { Id = 2, CityId = 1, Description = "The Pasig River is a river in the Philippines that connects Laguna de Bay to Manila Bay", Name = "Pasig River" },
                        new { Id = 3, CityId = 2, Description = "Greenbelt is a shopping mall located at Ayala Center", Name = "Greenbelt" },
                        new { Id = 4, CityId = 3, Description = "Cheap bargains", Name = "Divisoria" },
                        new { Id = 5, CityId = 3, Description = "Chinese people", Name = "Binondo" },
                        new { Id = 6, CityId = 3, Description = "Park of Rizal", Name = "Rizal Park" }
                    );
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.HasOne("CityInfo.API.Entities.Mayor", "Mayor")
                        .WithMany()
                        .HasForeignKey("MayorId");
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

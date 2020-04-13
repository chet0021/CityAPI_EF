﻿// <auto-generated />
using CityInfo.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityInfo.API.Migrations.MayorInfo
{
    [DbContext(typeof(MayorInfoContext))]
    [Migration("20200413092815_AddedGenderColumn")]
    partial class AddedGenderColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityInfo.API.Entities.Mayor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Gender")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Mayor");

                    b.HasData(
                        new { Id = 1, Age = 45, Gender = "M", Name = "Isko Moreno" },
                        new { Id = 2, Age = 42, Gender = "M", Name = "Francis Zamora" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}

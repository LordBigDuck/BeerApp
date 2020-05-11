﻿// <auto-generated />
using System;
using BeerApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeerApp.Infrastructure.Migrations
{
    [DbContext(typeof(BeerContext))]
    [Migration("20200510182539_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerApp.Core.Models.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AlcoholLevel")
                        .HasColumnType("float");

                    b.Property<int?>("BrewerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrewerId");

                    b.ToTable("Beers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlcoholLevel = 6.5999999999999996,
                            BrewerId = 1,
                            IsActive = true,
                            Name = "Leffe Blonde",
                            Price = 2.2000000000000002
                        },
                        new
                        {
                            Id = 2,
                            AlcoholLevel = 8.5999999999999996,
                            BrewerId = 1,
                            IsActive = true,
                            Name = "Leffe Brune",
                            Price = 2.7999999999999998
                        });
                });

            modelBuilder.Entity("BeerApp.Core.Models.Brewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brewers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Abbaye de Leffe"
                        });
                });

            modelBuilder.Entity("BeerApp.Core.Models.Wholesaler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("BeerApp.Core.Models.WholesalerBeer", b =>
                {
                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("WholesalerId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("BeerId", "WholesalerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("WholesalerBeer");
                });

            modelBuilder.Entity("BeerApp.Core.Models.Beer", b =>
                {
                    b.HasOne("BeerApp.Core.Models.Brewer", "Brewer")
                        .WithMany("Beers")
                        .HasForeignKey("BrewerId");
                });

            modelBuilder.Entity("BeerApp.Core.Models.WholesalerBeer", b =>
                {
                    b.HasOne("BeerApp.Core.Models.Beer", "Beer")
                        .WithMany("WholesalerBeers")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerApp.Core.Models.Wholesaler", "Wholesaler")
                        .WithMany("WholesalerBeers")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
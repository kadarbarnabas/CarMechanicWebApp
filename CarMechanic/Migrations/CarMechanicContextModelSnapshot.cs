﻿// <auto-generated />
using System;
using CarMechanic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarMechanic.Migrations
{
    [DbContext(typeof(CarMechanicContext))]
    partial class CarMechanicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("CarMechanic.Shared.Customer", b =>
                {
                    b.Property<Guid>("Ugyfelszam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lakcim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Ugyfelszam");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarMechanic.Shared.Work", b =>
                {
                    b.Property<Guid>("MunkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Allapot")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BecsultOra")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GyartasiEv")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HibaSulyossag")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HibakLeirasa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rendszam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ugyfelszam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MunkaId");

                    b.ToTable("Works");
                });
#pragma warning restore 612, 618
        }
    }
}

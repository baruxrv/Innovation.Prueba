﻿// <auto-generated />
using System;
using Innovation.DGT.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Innovation.DGT.WebApi.Migrations
{
    [DbContext(typeof(DgtDbContext))]
    [Migration("20190130225437_Initialice")]
    partial class Initialice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Innovation.DGT.DBContext.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("CreateUser");

                    b.Property<string>("Dni")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<short>("Points");

                    b.Property<string>("Surnames")
                        .IsRequired();

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("UpdateUser");

                    b.HasKey("Id");

                    b.HasIndex("Dni")
                        .IsUnique();

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("Innovation.DGT.DBContext.Entities.DriverVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("CreateUser");

                    b.Property<int>("DriverId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("UpdateUser");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("DriverVehicle");
                });

            modelBuilder.Entity("Innovation.DGT.DBContext.Entities.Infringement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("CreateUser");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<short>("Points");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("UpdateUser");

                    b.HasKey("Id");

                    b.ToTable("Infringement");
                });

            modelBuilder.Entity("Innovation.DGT.DBContext.Entities.InfringementDriverVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("CreateUser");

                    b.Property<int>("DriverVehicleId");

                    b.Property<int>("InfringementId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("UpdateUser");

                    b.HasKey("Id");

                    b.HasIndex("DriverVehicleId");

                    b.HasIndex("InfringementId");

                    b.ToTable("InfringementDriverVehicle");
                });

            modelBuilder.Entity("Innovation.DGT.DBContext.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("CreateUser");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Registration")
                        .IsRequired();

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("UpdateUser");

                    b.HasKey("Id");

                    b.HasIndex("Registration")
                        .IsUnique();

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Innovation.DGT.DBContext.Entities.DriverVehicle", b =>
                {
                    b.HasOne("Innovation.DGT.DBContext.Entities.Driver", "Driver")
                        .WithMany("DriverVehicle")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Innovation.DGT.DBContext.Entities.Vehicle", "Vehicle")
                        .WithMany("DriverVehicle")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Innovation.DGT.DBContext.Entities.InfringementDriverVehicle", b =>
                {
                    b.HasOne("Innovation.DGT.DBContext.Entities.DriverVehicle", "DriverVehicle")
                        .WithMany("InfringementDriverVehicle")
                        .HasForeignKey("DriverVehicleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Innovation.DGT.DBContext.Entities.Infringement", "Infringement")
                        .WithMany("InfringementDriverVehicle")
                        .HasForeignKey("InfringementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

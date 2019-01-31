using System;
using Innovation.DGT.DBContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Innovation.DGT.DBContext
{
    public class DgtDbContext : DbContext
    {


        public DgtDbContext()
        {


        }

        public DgtDbContext(DbContextOptions<DgtDbContext> options) : base(options)
        {

        }

        public DbSet<Driver> Driver { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<Infringement> Infringement { get; set; }

        public DbSet<DriverVehicle> DriverVehicle { get; set; }

        public DbSet<InfringementDriverVehicle> InfringementDriverVehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Filename=./Dgt.db");



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasIndex(p => p.Dni)
                .IsUnique(true);

                 modelBuilder.Entity<Vehicle>()
                .HasIndex(p => p.Registration)
                .IsUnique(true);
                
        }
    }
}

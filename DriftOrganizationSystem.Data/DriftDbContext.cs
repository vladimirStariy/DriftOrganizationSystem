using DriftOrganizationSystem.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Data
{
    public class DriftDbContext : DbContext
    {
        public DriftDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DriftDbContext(DbContextOptions<DriftDbContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Pilot> Pilots { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DriftDb;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilot>(builder =>
            {
                builder.ToTable("Pilots").HasKey(x => x.Pilot_ID);

                builder.Property(x => x.Pilot_ID).ValueGeneratedOnAdd();


            });

            

            modelBuilder.Entity<Car>(builder =>
            {
                builder.ToTable("Cars").HasKey(x => x.Car_ID);

                builder.Property(x => x.Car_ID).ValueGeneratedOnAdd();

                builder.HasOne(x => x.Pilot)
                       .WithMany(x => x.Cars)
                       .HasForeignKey(x => x.Pilot_ID);
            });
                
            modelBuilder.Entity<Achievement>(builder =>
            {
                builder.ToTable("Achievements").HasKey(x => x.Achievement_ID);

                builder.Property(x => x.Achievement_ID).ValueGeneratedOnAdd();

                builder.HasOne(x => x.Pilot)
                       .WithMany(x => x.Achievements)
                       .HasForeignKey(x => x.Pilot_ID);
            });
        }
    }
}

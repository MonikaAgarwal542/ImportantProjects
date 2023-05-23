using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using CampBookingApi.Repository.Entites;
using Data_Access_layer.Repository.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CampBookingApi.Repository
{
    public  class CampDbContext : DbContext
    {
        /*public CampDbContext()
        {
        }*/

        public CampDbContext(DbContextOptions<CampDbContext> options)
            : base(options)
        {
        }

        public  DbSet<Users> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Camps> Camps { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=IN-PG02C8LJ;Initial Catalog=CampDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}

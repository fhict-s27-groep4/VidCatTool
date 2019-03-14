using Data_Layer.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data_Layer
{
    public class VidCatToolContext : DbContext
    {
        public VidCatToolContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(ru => ru.Users)
                .IsRequired();

            modelBuilder.Entity<Rating>()
                .HasOne(u => u.User)
                .WithMany(r => r.Ratings);

            modelBuilder.Entity<Rating>()
                .HasOne(v => v.Video)
                .WithMany(r => r.Ratings);
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

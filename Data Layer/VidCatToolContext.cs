using Microsoft.EntityFrameworkCore;
using Model_Layer.Models;
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
            modelBuilder.Entity<Rating>()
                .HasOne(u => u.User)
                .WithMany(r => r.Ratings);

            modelBuilder.Entity<Rating>()
                .HasOne(v => v.Video)
                .WithMany(r => r.Ratings);

            modelBuilder.Entity<Rating>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Ratings);
        }

        public DbSet<Video> Video { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
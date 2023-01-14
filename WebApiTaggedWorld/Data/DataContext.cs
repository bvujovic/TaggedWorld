using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;
using TaggedWorldLibrary.Model;

namespace WebApiTaggedWorld.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Member> Member { get; set; } = default!;
        public DbSet<Group> Group { get; set; } = default!;
        public DbSet<Sharing> Sharing { get; set; } = default!;
        public DbSet<Target> Targets { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Data/tw.db");

            //dotnet ef migrations add CreateInitial --project WebApiTaggedWorld
            // Add-Migration InitialCreate
            //dotnet ef database update
            // Update-Database
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasAlternateKey(c => c.Username);
            builder.Entity<User>().HasAlternateKey(c => c.Email);

            builder.Entity<User>().HasMany(u => u.OwnedTargets).WithOne(t => t.UserOwner);
            builder.Entity<User>().HasMany(u => u.ModifiedTargets).WithOne(t => t.UserModified);
            builder.Entity<User>().HasMany(u => u.AccessedTargets).WithOne(t => t.UserAccessed);

            builder.Entity<Member>().HasKey(it => new { it.UserId, it.GroupId });

            builder.Entity<Sharing>().HasKey(s => new { s.TargetId, s.GroupId });
        }
    }
}

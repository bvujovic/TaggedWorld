using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;
using TaggedWorldLibrary.Model;

namespace WebApiTaggedWorld.Data
{
    /// <summary>
    /// Model podataka koji se trajno cuvaju u bazi.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>Korisnik.</summary>
        public DbSet<User> Users { get; set; } = default!;

        /// <summary>Clanstvo korisnika u grupi.</summary>
        public DbSet<Member> Member { get; set; } = default!;

        /// <summary>Grupa korisnika.</summary>
        public DbSet<Group> Group { get; set; } = default!;
        
        /// <summary>Deljenje: korisnik deli target sa grupom.</summary>
        //B public DbSet<Sharing> Sharing { get; set; } = default!;
        
        /// <summary>Target/Resource/Item - objekat (fajl/folder/link) koji se taguje.</summary>
        public DbSet<Target> Targets { get; set; } = default!;

        /// <summary></summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Data/tw.db");

            //dotnet ef migrations add CreateInitial --project WebApiTaggedWorld
            // Add-Migration InitialCreate
            //dotnet ef database update
            // Update-Database
        }

        /// <summary></summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasAlternateKey(c => c.Username);
            builder.Entity<User>().HasAlternateKey(c => c.Email);

            builder.Entity<User>().HasMany(u => u.OwnedTargets).WithOne(t => t.UserOwner);
            builder.Entity<User>().HasMany(u => u.ModifiedTargets).WithOne(t => t.UserModified);
            builder.Entity<User>().HasMany(u => u.AccessedTargets).WithOne(t => t.UserAccessed);

            builder.Entity<Member>().HasKey(it => new { it.UserId, it.GroupId });

            //B builder.Entity<Sharing>().HasKey(s => new { s.TargetId, s.GroupId });
        }
    }
}

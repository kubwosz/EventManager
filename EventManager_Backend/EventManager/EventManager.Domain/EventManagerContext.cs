using EventManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Domain
{
    public class EventManagerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EventManager;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimpleUser>().HasMany(e => e.Events).WithOne(s => s.SimpleUser).OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Lecture> Lectures { get; set; }
    }
}

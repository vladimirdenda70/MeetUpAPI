﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUpAPI.Entites
{
    public class MeetupContext : DbContext
    {

        string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MU_Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Lecture> Lectures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetup>()
                   .HasOne(m => m.Location)
                   .WithOne(l => l.Meetup)
                   .HasForeignKey<Location>(l => l.MeetupId);

            modelBuilder.Entity<Meetup>()
            .HasMany(m => m.Lectures)
            .WithOne(l => l.Meetup);

        }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

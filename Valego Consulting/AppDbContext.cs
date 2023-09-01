﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Valego_Consulting.Models;

namespace Valego_Consulting
{
    public class AppDbContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=ALEJANDROPC\SQLEXPRESS02;Database=BackEndDevTest;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>()
                .Property(a => a.Id)
                .ValueGeneratedNever();
        }
    }
}

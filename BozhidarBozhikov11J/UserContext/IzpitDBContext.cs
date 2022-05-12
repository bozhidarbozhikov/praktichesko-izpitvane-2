using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserContext
{
    public class IzpitDBContext : DbContext
    {
        public IzpitDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-CDDUI2J\SQLEXPRESS;Database=IzpitDB;Trusted_Connection=True;");
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Area> Areas { get; set; }
    }
}

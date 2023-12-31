﻿using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=superherodb;Trusted_Connection=True;TrustServerCertificate=true");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}

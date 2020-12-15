using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
   public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<portfolioitem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Owner>().HasData(
                
                new Owner()
                {
                    Id=Guid.NewGuid(),Avatar="AVATR1.JPEG",FullName="ITECH-CONSULTANTS",Profil="IT/CLOULD/MOBILE/ERP Systems"
                }
                
                
                );

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<portfolioitem> portfolioitems { get; set; }
    }
}

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
                    Id=Guid.NewGuid(),Avatar="AVATR1.JPEG",FullName="ITECH-CONSULTANTS",Profil= "Software Program/Maintenance And Network Surveillance Cameras/Mobile Applications/Cloud Management"
                }
                
                
                );

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<portfolioitem> portfolioitems { get; set; }

        /*
         dotnet ef database update -s C:\Users\Administrator\Source\Repos\portfolio\Web\Web.csproj
         */
    }
}

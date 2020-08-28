using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebLegends_test.DAL.Entities;
using WebLegends_test.DAL.Enums;

namespace WebLegends_test.DAL.Context
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityStatus> Statuses { get; set; }
        public DbSet<FacilityLog> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacilityStatus>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<FacilityStatus>()
               .Property(p => p.Name).IsRequired();
            modelBuilder.Entity<FacilityStatus>()
                .HasData(
                new FacilityStatus() { Name = "Active", Id = (int)FacilityStatuses.Active },
                new FacilityStatus() { Name = "Inactive", Id = (int)FacilityStatuses.Inactive },
                new FacilityStatus() { Name = "OnHold", Id = (int)FacilityStatuses.OnHold }
                );
            base.OnModelCreating(modelBuilder);

        }
    }
}

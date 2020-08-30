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
		public DbSet<FacilityStatus> FacilityStatuses { get; set; }
		public DbSet<FacilityLog> FacilityLogs { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FacilityStatus>()
				.ToTable("FacilityStatuses");
			modelBuilder.Entity<FacilityStatus>()
				.HasKey(k => k.Id);
			modelBuilder.Entity<FacilityStatus>()
			   .Property(p => p.Name).IsRequired();
			modelBuilder.Entity<FacilityStatus>()
				.HasData(
				new FacilityStatus() { Name = "Active", Id = (int)Enums.FacilityStatuses.Active },
				new FacilityStatus() { Name = "Inactive", Id = (int)Enums.FacilityStatuses.Inactive },
				new FacilityStatus() { Name = "OnHold", Id = (int)Enums.FacilityStatuses.OnHold }
				);

			modelBuilder.Entity<Facility>()
			  .HasKey(k => k.Id);
			modelBuilder.Entity<Facility>()
			   .Property(p => p.Name).IsRequired();
			modelBuilder.Entity<Facility>()
			   .Property(p => p.Email).IsRequired();
			modelBuilder.Entity<Facility>()
			   .Property(p => p.Address).IsRequired();
			modelBuilder.Entity<Facility>()
			   .Property(p => p.Phone_Number).IsRequired();

			modelBuilder.Entity<FacilityLog>()
				.ToTable("FacilityLogs");
			modelBuilder.Entity<FacilityLog>()
			  .HasKey(k => k.Id);
			modelBuilder.Entity<FacilityLog>()
			   .Property(p => p.ChangeDate).IsRequired();
			modelBuilder.Entity<FacilityLog>()
			   .Property(p => p.FieldName).IsRequired();
			modelBuilder.Entity<FacilityLog>()
			   .Property(p => p.NewValue).IsRequired();
			modelBuilder.Entity<FacilityLog>()
			   .Property(p => p.OldValue).IsRequired();

			base.OnModelCreating(modelBuilder);

		}
	}
}

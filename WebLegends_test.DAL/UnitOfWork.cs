using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.DAL.Context;
using WebLegends_test.DAL.Entities;
using WebLegends_test.DAL.Interfaces;
using WebLegends_test.DAL.Repositories;

namespace WebLegends_test.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(EfContext _context)
		{
			db = _context;

		}
		private readonly EfContext db;
		private FacilityRepository facilitiesRepository;
		private FacilityLogRepository logsRepository;
		private FacilityStatusRepository statusesRepository;


		public IRepositoryAsync<Facility, int> Facilities
		{
			get
			{
				if (facilitiesRepository == null)
					facilitiesRepository = new FacilityRepository(db);
				return facilitiesRepository;
			}
		}

		public IRepositoryAsync<FacilityLog, int> FacilityLogs
		{
			get
			{
				if (logsRepository == null)
					logsRepository = new FacilityLogRepository(db);
				return logsRepository;
			}
		}

		public IRepositoryAsync<FacilityStatus, int> FacilityStatuses
		{
			get
			{
				if (statusesRepository == null)
					statusesRepository = new FacilityStatusRepository(db);
				return statusesRepository;
			}
		}

		public async Task SaveAsync()
		{
			await db.SaveChangesAsync();
		}


		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
			}
			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
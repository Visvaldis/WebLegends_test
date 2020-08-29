﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.DAL.Context;
using WebLegends_test.DAL.Entities;
using WebLegends_test.DAL.Interfaces;

namespace WebLegends_test.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(EfContext _context)
		{
			db = _context;

		}
		private EfContext db;
		private FacilityRepository facilitiesRepository;
		private FacilityLogRepository logsRepository;
		private FacilityStatusRepository statusesRepository;


		public IRepository<Facility> Facilities
		{
			get
			{
				if (facilitiesRepository == null)
					facilitiesRepository = new FacilityRepository(db);
				return facilitiesRepository;
			}
		}

		public IRepository<FacilityLog> Logs
		{
			get
			{
				if (logsRepository == null)
					logsRepository = new FacilityLogRepository(db);
				return logsRepository;
			}
		}

		public IRepository<FacilityStatus> Statuses
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


		public void Save()
		{
			db.SaveChanges();
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
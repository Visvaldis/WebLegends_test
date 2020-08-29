using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebLegends_test.DAL.Context;
using WebLegends_test.DAL.Entities;
using WebLegends_test.DAL.Interfaces;

namespace WebLegends_test.DAL.Repositories
{
	class FacilityLogRepository : IRepository<FacilityLog>
	{
		private EfContext db;
		public FacilityLogRepository(EfContext context)
		{
			this.db = context;
		}
		public int Create(FacilityLog item)
		{
			var fasility = db.Facilities.FirstOrDefault(t => t.Name == item.Facility.Name);
			if (fasility != null)
			{
				item.Facility = fasility;
			}

			db.Logs.Add(item);
			db.SaveChanges();
			return item.Id;
		}

		public void Delete(int id)
		{
			FacilityLog log = db.Logs.Find(id);
			if (log != null)
				db.Logs.Remove(log);
		}

		public IEnumerable<FacilityLog> Find(Expression<Func<FacilityLog, bool>> predicate)
		{
			return db.Logs.Where(predicate).ToList();
		}

		public FacilityLog Get(int id)
		{
			return GetAllQuary()
				.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<FacilityLog> GetAll()
		{
			return GetAllQuary().ToArray();
		}

		public void Update(FacilityLog item)
		{
			var entity = db.Logs.Find(item.Id);
			if (entity == null)
			{
				return;
			}
			var fasility = db.Facilities.FirstOrDefault(t => t.Name == item.Facility.Name);
			if (fasility != null)
			{
				item.Facility = fasility;
			}
			db.Entry(entity).CurrentValues.SetValues(item);
		}


		private IQueryable<FacilityLog> GetAllQuary()
		{
			return db.Logs.Include(x => x.Facility).ThenInclude(x => x.Status);
		}
	}
}

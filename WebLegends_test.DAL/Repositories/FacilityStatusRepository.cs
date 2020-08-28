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
	class FacilityStatusRepository : IRepository<FacilityStatus>
	{
		private EfContext db;
		public FacilityStatusRepository(EfContext context)
		{
			this.db = context;
		}
		public int Create(FacilityStatus item)
		{
			db.Statuses.Add(item);
			db.SaveChanges();
			return item.Id;
		}

		public void Delete(int id)
		{
			FacilityStatus status = db.Statuses.Find(id);
			if (status != null)
				db.Statuses.Remove(status);
		}

		public IEnumerable<FacilityStatus> Find(Expression<Func<FacilityStatus, bool>> predicate)
		{
			return db.Statuses.Where(predicate).ToList();
		}

		public FacilityStatus Get(int id)
		{
			return GetAllQuary()
				.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<FacilityStatus> GetAll()
		{
			return GetAllQuary().ToArray();
		}

		public void Update(FacilityStatus item)
		{
			var entity = db.Statuses.Find(item.Id);
			if (entity == null)
			{
				return;
			}
			db.Entry(entity).CurrentValues.SetValues(item);
		}


		private IQueryable<FacilityStatus> GetAllQuary()
		{
			return db.Statuses;
		}
	}
}

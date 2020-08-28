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
	class FacilityRepository : IRepository<Facility>
	{
		private EfContext db;
		public FacilityRepository(EfContext context)
		{
			this.db = context;
		}
		public int Create(Facility item)
		{
			db.Facilities.Add(item);
			db.SaveChanges();
			return item.Id;
		}

		public void Delete(int id)
		{
			Facility facility = db.Facilities.Find(id);
			if (facility != null)
				db.Facilities.Remove(facility);
		}

		public IEnumerable<Facility> Find(Expression<Func<Facility, bool>> predicate)
		{
			return db.Facilities.Where(predicate).ToList();
		}

		public Facility Get(int id)
		{
			return GetAllQuary()
				.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Facility> GetAll()
		{
			return GetAllQuary().ToArray();
		}

		public void Update(Facility item)
		{
			var entity = db.Facilities.Find(item.Id);
			if (entity == null)
			{
				return;
			}
			db.Entry(entity).CurrentValues.SetValues(item);
		}


		private IQueryable<Facility> GetAllQuary()
		{
			return db.Facilities;
		}
	}
}

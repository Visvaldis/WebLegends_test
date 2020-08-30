using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.DAL.Context;
using WebLegends_test.DAL.Entities;
using WebLegends_test.DAL.Interfaces;

namespace WebLegends_test.DAL.Repositories
{
	class FacilityRepository : BaseRepositoryAsync<Facility, int>
	{

		public FacilityRepository(EfContext context) :base(context)
		{ }
		public override async Task<int> Create(Facility item)
		{
			var status = db.FacilityStatuses.FirstOrDefault(t => t.Name == item.Status.Name);
			if (status != null)
			{
				item.Status = status;
			}
			db.Facilities.Add(item);
			await db.SaveChangesAsync();
			return item.Id;
		}

		public override async Task Update(Facility item)
		{
			var entity = await db.Facilities.FindAsync(item.Id);
			if (entity == null)
			{
				return;
			}
			var status = await db.FacilityStatuses.FirstOrDefaultAsync(t => t.Name == item.Status.Name);
			if (status != null)
			{
				entity.Status = status;
			}
			db.Entry(entity).CurrentValues.SetValues(item);
		}
		public override IQueryable<Facility> GetAllQuary()
		{
			return base.GetAllQuary().Include(x=> x.Status);
		}
	}
}

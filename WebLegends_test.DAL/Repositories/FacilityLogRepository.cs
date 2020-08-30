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
	class FacilityLogRepository : BaseRepositoryAsync<FacilityLog, int>
	{

		public FacilityLogRepository(EfContext context) : base(context)
		{ }

		public override async Task<int> Create(FacilityLog item)
		{
			db.FacilityLogs.Add(item);
			await db.SaveChangesAsync();
			return item.Id;
		}

		public override async Task Update(FacilityLog item)
		{
			var entity = await db.FacilityLogs.FindAsync(item.Id);
			if (entity == null)
			{
				return;
			}
			db.Entry(entity).CurrentValues.SetValues(item);
		}

	}
}

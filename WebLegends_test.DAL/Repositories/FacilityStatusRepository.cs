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
	class FacilityStatusRepository : BaseRepositoryAsync<FacilityStatus, int>
	{
		public FacilityStatusRepository(EfContext context) : base(context)
		{ }
		public override async Task<int> Create(FacilityStatus item)
		{
			db.FacilityStatuses.Add(item);
			await db.SaveChangesAsync();
			return item.Id;
		}



		//public override async Task Update(FacilityStatus item)
		//{
		//	var entity = db.FacilityStatuses.Filter(item.Id);
		//	if (entity == null)
		//	{
		//		return;
		//	}
		//	db.Entry(entity).CurrentValues.SetValues(item);
		//}

	}
}

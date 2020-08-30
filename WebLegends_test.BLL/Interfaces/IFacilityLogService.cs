using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.BLL.DTO;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IFacilityLogService : IService<FacilityLogDTO>
	{
		Task<ICollection<FacilityLogDTO>> GetWithFilter(Expression<Func<FacilityLog, bool>> filter);
		Task DeleteByFacility(int facilityId);
		Task<ICollection<FacilityLogDTO>> GetByFacilityPage(int facilityId, int pageNumber, int pageSize);
		Task<ICollection<FacilityLogDTO>> GetPage(int pageNumber, int pageSize);
	}
}

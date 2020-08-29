using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebLegends_test.BLL.DTO;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IFacilityLogService :IService<FacilityLogDTO>
	{
		ICollection<FacilityLogDTO> GetWithFilter(Expression<Func<FacilityLog, bool>> filter);
		ICollection<FacilityLogDTO> GetByFacility(string name);
		ICollection<FacilityLogDTO> GetByFacilityId(int id);
		void DeleteByFacility(int facilityId);

	}
}

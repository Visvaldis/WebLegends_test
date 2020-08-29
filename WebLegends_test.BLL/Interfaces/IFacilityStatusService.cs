using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebLegends_test.BLL.DTO;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IFacilityStatusService:IService<FacilityStatusDTO>
	{
		ICollection<FacilityStatusDTO> GetWithFilter(Expression<Func<FacilityStatus, bool>> filter);
		ICollection<FacilityStatusDTO> GetByName(string name);
	}
}

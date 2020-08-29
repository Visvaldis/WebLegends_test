using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebLegends_test.BLL.DTO;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IFacilityService:IService<FacilityDTO>
	{
		ICollection<FacilityDTO> GetWithFilter(Expression<Func<Facility, bool>> filter);
		ICollection<FacilityDTO> GetByName(string name);
		ICollection<FacilityDTO> GetByStatus(string status);
	}
}

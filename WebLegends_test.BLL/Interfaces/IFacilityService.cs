using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.BLL.DTO;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IFacilityService: IService<FacilityDTO>
	{
		Task<ICollection<FacilityDTO>> GetWithFilter(Expression<Func<Facility, bool>> filter);
		Task<ICollection<FacilityDTO>> GetByName(string name);
		Task<ICollection<FacilityDTO>> GetByStatus(string status);
		Task<ICollection<FacilityDTO>> GetPage(int pageNumber, int pageSize);

	}
}

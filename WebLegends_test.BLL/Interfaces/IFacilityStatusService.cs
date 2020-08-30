using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.BLL.DTO;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IFacilityStatusService : IService<FacilityStatusDTO>
	{
		Task<ICollection<FacilityStatusDTO>> GetWithFilter(Expression<Func<FacilityStatus, bool>> filter);
		Task<FacilityStatusDTO> GetByName(string name);
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepositoryAsync<Facility, int> Facilities { get; }
		IRepositoryAsync<FacilityLog, int> FacilityLogs { get; }
		IRepositoryAsync<FacilityStatus, int> FacilityStatuses { get; }
		Task SaveAsync();
	}
}

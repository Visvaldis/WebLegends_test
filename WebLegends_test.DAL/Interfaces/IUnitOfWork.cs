using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.DAL.Interfaces
{
	public interface IUnitOfWork :IDisposable
	{
		IRepository<Facility> Facilities { get; }
		IRepository<FacilityLog> Logs { get; }
		IRepository<FacilityStatus> Statuses { get; }
		void Save();
		Task SaveAsync();
	}
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebLegends_test.BLL.DTO;
using WebLegends_test.BLL.Infrastructure;
using WebLegends_test.BLL.Interfaces;
using WebLegends_test.DAL.Entities;
using WebLegends_test.DAL.Interfaces;

namespace WebLegends_test.BLL.Services
{
	public class FacilityLogService : IFacilityLogService
	{
		IUnitOfWork Database { get; set; }
		IMapper Mapper { get; set; }
		public FacilityLogService(IUnitOfWork uow)
		{
			Database = uow;
			Mapper = Mappers.FacilityMapper;
		}
		public int Add(FacilityLogDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Facility log is null. Try again.");
			var facilityLog = Mapper.Map<FacilityLogDTO, FacilityLog>(item);
			int id = Database.Logs.Create(facilityLog);
			return id;
		}

		public void Delete(int id)
		{
			Database.Logs.Delete(id);
			Database.Save();
		}
		public void Dispose()
		{
			Database.Dispose();
		}

		public bool Exist(int id)
		{
			var facilityLog = Database.Logs.Get(id);
			return !(facilityLog == null);
		}

		public FacilityLogDTO Get(int id)
		{
			var facilityLog = Database.Logs.Get(id);
			if (facilityLog == null)
				throw new ValidationException("Facility log is not found");

			return Mapper.Map<FacilityLog, FacilityLogDTO>(facilityLog);

		}

		public ICollection<FacilityLogDTO> GetAll()
		{
			var query = Database.Logs.GetAll();
			var facilitiesLogs = query.ToList();
			return Mapper.Map<IEnumerable<FacilityLog>, List<FacilityLogDTO>>(facilitiesLogs);
		}

		public ICollection<FacilityLogDTO> GetByFacility(string name)
		{
			return GetWithFilter(x => x.Facility.Name ==name);
		}
		public ICollection<FacilityLogDTO> GetByFacilityId(int id)
		{
			return GetWithFilter(x => x.Facility.Id == id);
		}

		public ICollection<FacilityLogDTO> GetWithFilter(Expression<Func<FacilityLog, bool>> filter)
		{
			var a = Database.Logs.Find(filter);
			var list = a.AsEnumerable<FacilityLog>();
			return Mapper.Map<IEnumerable<FacilityLog>, List<FacilityLogDTO>>
				(list);
		}

		public void Update(FacilityLogDTO item)
		{
			Database.Logs.Update(Mapper.Map<FacilityLogDTO, FacilityLog>(item));
			Database.Save();
		}
	}
}

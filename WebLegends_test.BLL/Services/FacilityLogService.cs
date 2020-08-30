using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.BLL.DTO;
using WebLegends_test.BLL.Infrastructure;
using WebLegends_test.BLL.Interfaces;
using WebLegends_test.DAL.Entities;
using WebLegends_test.DAL.Interfaces;

namespace WebLegends_test.BLL.Services
{
	public class FacilityLogService : BaseService, IFacilityLogService
	{
		public FacilityLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }
		public async Task<int> Create(FacilityLogDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Facility log is null. Try again.");
			var facilityLog = mapper.Map<FacilityLogDTO, FacilityLog>(item);
			int id = await unitOfWork.FacilityLogs.Create(facilityLog);
			return id;
		}

		public async Task Delete(int id)
		{
			await unitOfWork.FacilityLogs.Delete(id);
			await unitOfWork.SaveAsync();
		}
		public void Dispose()
		{
			unitOfWork.Dispose();
		}

		public async Task<bool> Exist(int id)
		{
			var facilityLog = await unitOfWork.FacilityLogs.Get(id);
			return !(facilityLog == null);
		}

		public async Task<FacilityLogDTO> Get(int id)
		{
			var facilityLog = await unitOfWork.FacilityLogs.Get(id);
			if (facilityLog == null)
				throw new ValidationException("Facility log is not found");

			return mapper.Map<FacilityLog, FacilityLogDTO>(facilityLog);

		}

		public async Task<ICollection<FacilityLogDTO>> GetAll()
		{
			var facilitiesLogs = await unitOfWork.FacilityLogs.GetAll();
			return mapper.Map<IEnumerable<FacilityLog>, List<FacilityLogDTO>>(facilitiesLogs);
		}


		public async Task<ICollection<FacilityLogDTO>> GetWithFilter(Expression<Func<FacilityLog, bool>> filter)
		{
			var list = await unitOfWork.FacilityLogs.Filter(filter);
			return mapper.Map<IEnumerable<FacilityLog>, List<FacilityLogDTO>>
				(list);
		}

		public async Task Update(FacilityLogDTO item)
		{
			await unitOfWork.FacilityLogs.Update(mapper.Map<FacilityLogDTO, FacilityLog>(item));
			await unitOfWork.SaveAsync();
		}

		public async Task DeleteByFacility(int facilityId)
		{
			var logs = await GetWithFilter(x => x.FacilityId == facilityId);
			foreach (var item in logs)
			{
				await unitOfWork.FacilityLogs.Delete(item.Id);
			}
			await unitOfWork.SaveAsync();
		}

		public async Task<ICollection<FacilityLogDTO>> GetPage(int pageNumber, int pageSize)
		{
			var list = (await unitOfWork.FacilityLogs.GetAll())
				.OrderByDescending(on => on.ChangeDate)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();
			return mapper.Map<IEnumerable<FacilityLog>, List<FacilityLogDTO>>(list);
		}

		public async Task<ICollection<FacilityLogDTO>> GetByFacilityPage(int facilityId, int pageNumber, int pageSize)
		{
			var facility = await unitOfWork.Facilities.Get(facilityId);
			if (facility == null)
				throw new ValidationException();
			var list = (await unitOfWork.FacilityLogs.GetAll())
				.Where(x => x.FacilityId == facilityId)
				.OrderByDescending(on => on.ChangeDate)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			return mapper.Map<IEnumerable<FacilityLog>, List<FacilityLogDTO>>
				(list);
		}
	}
}

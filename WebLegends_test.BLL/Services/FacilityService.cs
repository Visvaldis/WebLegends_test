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
	public class FacilityService : BaseService, IFacilityService
	{
		public FacilityService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }

		public async Task<int> Create(FacilityDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Facility is null. Try again.");
			var facility = mapper.Map<FacilityDTO, Facility>(item);
			int id = await unitOfWork.Facilities.Create(facility);
			return id;
		}

		public async Task Delete(int id)
		{
			await unitOfWork.Facilities.Delete(id);
			await unitOfWork.SaveAsync();
		}

		public void Dispose()
		{
			unitOfWork.Dispose();
		}

		public async Task<bool> Exist(int id)
		{
			var facility = await unitOfWork.Facilities.Get(id);
			return !(facility == null);
		}

		public async Task<FacilityDTO> Get(int id)
		{
			var facility = await unitOfWork.Facilities.Get(id);
			if (facility == null)
				throw new ValidationException("Facility is not found");

			return mapper.Map<Facility, FacilityDTO>(facility);

		}

		public async Task<ICollection<FacilityDTO>> GetAll()
		{
			var facilities = await unitOfWork.Facilities.GetAll();
			return mapper.Map<IEnumerable<Facility>, List<FacilityDTO>>(facilities);
		}

		public async Task<ICollection<FacilityDTO>> GetWithFilter(Expression<Func<Facility, bool>> filter)
		{
			var list = await unitOfWork.Facilities.Filter(filter);
			return mapper.Map<IEnumerable<Facility>, List<FacilityDTO>>
				(list);
		}


		public async Task<ICollection<FacilityDTO>> GetByName(string name)
		{
			return await GetWithFilter(x => x.Name.Contains(name));
		}

		public async Task Update(FacilityDTO item)
		{
			var oldItem = await unitOfWork.Facilities.Get(item.Id);
			var newItem = mapper.Map<FacilityDTO, Facility>(item);

			List<FacilityLog> logs = new List<FacilityLog>();
			foreach (var prop in oldItem.GetType().GetProperties())
			{
				if (prop.Name == "FacilityLogs") continue;
				var oldOne = prop.GetValue(oldItem, null);
				var newOne = prop.GetValue(newItem);
				if (!oldOne.Equals(newOne))
				{
					logs.Add(
						new FacilityLog
						{
							FacilityId = newItem.Id,
							FieldName = prop.Name,
							NewValue = newOne.ToString(),
							OldValue = oldOne.ToString(),
							ChangeDate = DateTime.Now
						});
				}
			}
			await unitOfWork.Facilities.Update(newItem);
			await unitOfWork.SaveAsync();
			foreach (var log in logs)
			{
				await unitOfWork.FacilityLogs.Create(log);
			}
		}

		public async Task<ICollection<FacilityDTO>> GetByStatus(string status)
		{
			return await GetWithFilter(x => x.Status.Name == status);
		}

		public async Task<ICollection<FacilityDTO>> GetPage(int pageNumber, int pageSize)
		{
			var query = await unitOfWork.Facilities.GetAll();
			var page = query.OrderByDescending(on => on.Name)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize);
			var list = page.ToList();
			return mapper.Map<IEnumerable<Facility>, List<FacilityDTO>>(list);
		}
	}
}

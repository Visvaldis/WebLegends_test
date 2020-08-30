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
	public class FacilityStatusService : BaseService, IFacilityStatusService
	{
		public FacilityStatusService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }

		public async Task<int> Create(FacilityStatusDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Facility status is null. Try again.");

			var status = await unitOfWork.FacilityStatuses.Find(x => x.Name.ToLower() == item.Name.ToLower());
			if (status != default(FacilityStatus))
				throw new ValidationException(status.Id.ToString());
			else
			{
				int id = await unitOfWork.FacilityStatuses.Create(mapper.Map<FacilityStatusDTO, FacilityStatus>(item));
				return id;
			}
		}
		public async Task Delete(int id)
		{
			await unitOfWork.FacilityStatuses.Delete(id);
			await unitOfWork.SaveAsync();
		}

		public void Dispose()
		{
			unitOfWork.Dispose();
		}

		public async Task<bool> Exist(int id)
		{
			var status = await unitOfWork.FacilityStatuses.Get(id);
			return !(status == null);
		}

		public async Task<FacilityStatusDTO> Get(int id)
		{
			var status = await unitOfWork.FacilityStatuses.Get(id);
			if (status == null)
				throw new ValidationException("Status is not found");

			return mapper.Map<FacilityStatus, FacilityStatusDTO>(status);

		}

		public async Task<ICollection<FacilityStatusDTO>> GetAll()
		{
			var statuses = await unitOfWork.FacilityStatuses.GetAll();
			return mapper.Map<IEnumerable<FacilityStatus>, List<FacilityStatusDTO>>(statuses);

		}

		public async Task<FacilityStatusDTO> GetByName(string name)
		{
			var item = await unitOfWork.FacilityStatuses.Find(x => x.Name.Contains(name));
			return mapper.Map<FacilityStatus, FacilityStatusDTO>(item);
		}

		public async Task<ICollection<FacilityStatusDTO>> GetWithFilter(Expression<Func<FacilityStatus, bool>> filter)
		{
			var list = await unitOfWork.FacilityStatuses.Filter(filter);
			return mapper.Map<IEnumerable<FacilityStatus>, List<FacilityStatusDTO>>(list);

		}

		public async Task Update(FacilityStatusDTO item)
		{
			await unitOfWork.FacilityStatuses.Update(mapper.Map<FacilityStatusDTO, FacilityStatus>(item));
			await unitOfWork.SaveAsync();
		}
	}
}

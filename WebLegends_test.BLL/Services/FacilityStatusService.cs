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
	public class FacilityStatusService : IFacilityStatusService
	{
		IUnitOfWork Database { get; set; }
		IMapper Mapper { get; set; }
		public FacilityStatusService(IUnitOfWork uow)
		{
			Database = uow;
			Mapper = Mappers.FacilityMapper;
		}
		public int Add(FacilityStatusDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Facility is null. Try again.");
			var status = Mapper.Map<FacilityStatusDTO, FacilityStatus>(item);
			int id = Database.Statuses.Create(status);
			return id;
		}
		public void Delete(int id)
		{
			Database.Statuses.Delete(id);
			Database.Save();
		}

		public void Dispose()
		{
			Database.Dispose();
		}

		public bool Exist(int id)
		{
			var status = Database.Statuses.Get(id);
			return !(status == null);
		}

		public FacilityStatusDTO Get(int id)
		{
			var status = Database.Statuses.Get(id);
			if (status == null)
				throw new ValidationException("Status is not found");

			return Mapper.Map<FacilityStatus, FacilityStatusDTO>(status);

		}

		public ICollection<FacilityStatusDTO> GetAll()
		{
			var query = Database.Statuses.GetAll();
			var statuses = query.ToList();
			return Mapper.Map<IEnumerable<FacilityStatus>, List<FacilityStatusDTO>>(statuses);

		}

		public ICollection<FacilityStatusDTO> GetByName(string name)
		{
			return GetWithFilter(x => x.Name.Contains(name));
		}

		public ICollection<FacilityStatusDTO> GetWithFilter(Expression<Func<FacilityStatus, bool>> filter)
		{
			var a = Database.Statuses.Find(filter);
			var list = a.AsEnumerable<FacilityStatus>();
			return Mapper.Map<IEnumerable<FacilityStatus>, List<FacilityStatusDTO>>
				(list);

		}

		public void Update(FacilityStatusDTO item)
		{
			Database.Statuses.Update(Mapper.Map<FacilityStatusDTO, FacilityStatus>(item));
			Database.Save();
		}
	}
}

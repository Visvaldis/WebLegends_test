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
	public class FacilityService : IFacilityService
	{
		IUnitOfWork Database { get; set; }
		IMapper Mapper { get; set; }
		public FacilityService(IUnitOfWork uow)
		{
			Database = uow;
			Mapper = Mappers.FacilityMapper;
		}
		public int Add(FacilityDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Facility is null. Try again.");
			var facility = Mapper.Map<FacilityDTO, Facility>(item);
			int id = Database.Facilities.Create(facility);
			return id;
		}

		public void Delete(int id)
		{
			Database.Facilities.Delete(id);
			Database.Save();
		}

		public void Dispose()
		{
			Database.Dispose();
		}

		public bool Exist(int id)
		{
			var facility = Database.Facilities.Get(id);
			return !(facility == null);
		}

		public FacilityDTO Get(int id)
		{
			var facility = Database.Facilities.Get(id);
			if (facility == null)
				throw new ValidationException("Facility is not found");

			return Mapper.Map<Facility, FacilityDTO>(facility);

		}

		public ICollection<FacilityDTO> GetAll()
		{
			var query = Database.Facilities.GetAll();
			var facilities = query.ToList();
			return Mapper.Map<IEnumerable<Facility>, List<FacilityDTO>>(facilities);
		}

		public ICollection<FacilityDTO> GetWithFilter(Expression<Func<Facility, bool>> filter)
		{
			var a = Database.Facilities.Find(filter);
			var list = a.AsEnumerable<Facility>();
			return Mapper.Map<IEnumerable<Facility>, List<FacilityDTO>>
				(list);
		}


		public ICollection<FacilityDTO> GetByName(string name)
		{
			return GetWithFilter(x => x.Name.Contains(name));
		}

		public void Update(FacilityDTO item)
		{
			var oldItem = Database.Facilities.Get(item.Id);
			var newItem = Mapper.Map<FacilityDTO, Facility>(item);
			var props = typeof(FacilityDTO).GetProperties();
			List<FacilityLog> logs = new List<FacilityLog>();
			foreach (var prop in oldItem.GetType().GetProperties())
			{
				var oldOne = prop.GetValue(oldItem, null);
				var newOne = prop.GetValue(newItem);
				if(!oldOne.Equals(newOne))
				{
					logs.Add(
						new FacilityLog { Facility=newItem, FieldName=prop.Name,
							NewValue=newOne.ToString(), OldValue=oldOne.ToString(), 
							ChangeDate=DateTime.Now });
				}
			}
			Database.Facilities.Update(newItem);
			Database.Save();
			foreach (var log in logs)
			{
				Database.Logs.Create(log);
			}
		}

		public ICollection<FacilityDTO> GetByStatus(string status)
		{
			return GetWithFilter(x => x.Status.Name == status);
		}

		public ICollection<FacilityDTO> GetPage(int PageNumber, int PageSize)
		{
			var query = Database.Facilities.GetAll();
			var page = query.OrderBy(on => on.Name)
				.Skip((PageNumber - 1) * PageSize)
				.Take(PageSize);
			var list = page.ToList();
			return Mapper.Map<IEnumerable<Facility>, List<FacilityDTO>>
				(list);
		}
	}
}

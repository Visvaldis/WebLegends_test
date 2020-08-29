﻿using AutoMapper;
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
			Database.Facilities.Update(Mapper.Map<FacilityDTO, Facility>(item));
			Database.Save();
		}

		public ICollection<FacilityDTO> GetByStatus(string status)
		{
			return GetWithFilter(x => x.Status.Name == status);
		}
	}
}
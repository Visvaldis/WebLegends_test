using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebLegends_test.BLL.Infrastructure;
using WebLegends_test.DAL.Interfaces;

namespace WebLegends_test.BLL.Services
{
	public abstract class BaseService
	{
		protected readonly IUnitOfWork unitOfWork;
		protected readonly IMapper mapper;
		protected BaseService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = Mappers.FacilityMapper;
		}
	}
}

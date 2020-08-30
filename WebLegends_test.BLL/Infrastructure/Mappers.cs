using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebLegends_test.BLL.DTO;
using WebLegends_test.DAL.Entities;

namespace WebLegends_test.BLL.Infrastructure
{
	public class Mappers
	{
		public static IMapper FacilityMapper
		{
			get
			{
				var mapperCfg = new MapperConfiguration(cfg =>
				{
					cfg.CreateMap<Facility, FacilityDTO>().ReverseMap();
					cfg.CreateMap<FacilityStatus, FacilityStatusDTO>().ReverseMap();
					cfg.CreateMap<FacilityLog, FacilityLogDTO>().ReverseMap();


					cfg.CreateMap<Expression<Func<FacilityDTO, bool>>,
						Expression<Func<Facility, bool>>>();
					cfg.CreateMap<Expression<Func<FacilityStatusDTO, bool>>,
						Expression<Func<FacilityStatus, bool>>>();
					cfg.CreateMap<Expression<Func<FacilityLogDTO, bool>>,
						Expression<Func<FacilityLog, bool>>>();
				});
				return mapperCfg.CreateMapper();
			}
		}
	}
}

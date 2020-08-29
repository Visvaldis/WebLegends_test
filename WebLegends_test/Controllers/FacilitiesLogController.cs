using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebLegends_test.BLL.DTO;
using WebLegends_test.BLL.Interfaces;

namespace WebLegends_test.Controllers
{
	[Route("api/logs")]
	[ApiController]
	public class FacilitiesLogController : ControllerBase
	{
		IFacilityLogService logService;
		public FacilitiesLogController(IFacilityLogService service)
		{
			logService = service;


		}
		// GET: api/statuses
		[HttpGet]
		public ActionResult<IEnumerable<FacilityLogDTO>> Get()
		{
			try
			{
				var logs = logService.GetAll();
				return Ok(logs);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/statuses/5
		[HttpGet("{id}")]
		public ActionResult<FacilityStatusDTO> GetById(int id)
		{
			if (id <= 0)
				return BadRequest("Id is negative");
			try
			{
				var log = logService.Get(id);
				return Ok(log);
			}
			catch (ValidationException ex)
			{
				return NotFound();
			}
		}

		// DELETE api/statuses/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			if (!logService.Exist(id))
				return NotFound();

			logService.Delete(id);
			return NoContent();

		}

		[HttpGet("facility/{name:alpha}")]
		public ActionResult<IEnumerable<FacilityLogDTO>> GetByFacility(string name)
		{
			if (name is null || name == "")
				return BadRequest("Name is null");
			try
			{
				var facilities = logService.GetByFacility(name);
				return Ok(facilities);
			}
			catch (ValidationException ex)
			{
				return NotFound();
			}
		}

		[HttpDelete("facility/{id}")]
		public ActionResult<IEnumerable<FacilityLogDTO>> DeleteByFacility(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			logService.DeleteByFacility(id);
			return NoContent();

		}

		[HttpGet("page")]
		public ActionResult<IEnumerable<FacilityLogDTO>> GetPage(int number, int size)
		{
			if (number < 0 || size < 0)
				return BadRequest("Number or size is negative");

			var facilities = logService.GetPage(number, size);
			return Ok(facilities);
		}

	}
}

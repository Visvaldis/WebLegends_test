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
		private readonly IFacilityLogService logService;
		public FacilitiesLogController(IFacilityLogService service)
		{
			logService = service;


		}
		// GET: api/statuses
		[HttpGet]
		public async Task<ActionResult<IEnumerable<FacilityLogDTO>>> Get()
		{
			try
			{
				var logs = await logService.GetAll();
				return Ok(logs);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/statuses/5
		[HttpGet("{id}")]
		public async Task<ActionResult<FacilityStatusDTO>> GetById(int id)
		{
			if (id <= 0)
				return BadRequest("Id is negative");
			try
			{
				var log = await logService.Get(id);
				return Ok(log);
			}
			catch (ValidationException)
			{
				return NotFound();
			}
		}

		// DELETE api/statuses/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			if ((await logService.Exist(id)) == false)
				return NotFound();

			await logService.Delete(id);
			return NoContent();

		}


		[HttpGet("facility/{facilityId}/page")]
		public async Task<ActionResult<IEnumerable<FacilityLogDTO>>> GetByFacilityPage(int facilityId, int pageNumber, int pageSize)
		{
			if (facilityId <= 0)
				return BadRequest("Id is negative");
			if (pageNumber < 0 || pageSize < 0)
				return BadRequest("Page number or size is negative");
			try
			{
				var facilities = await logService.GetByFacilityPage(facilityId, pageNumber, pageSize);
				return Ok(facilities);
			}
			catch (ValidationException)
			{
				return NotFound();
			}
		}

		[HttpDelete("facility/{id}")]
		public async Task<ActionResult<IEnumerable<FacilityLogDTO>>> DeleteByFacility(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			await logService.DeleteByFacility(id);
			return NoContent();

		}

		[HttpGet("page")]
		public async Task<ActionResult<IEnumerable<FacilityLogDTO>>> GetPage(int pageNumber, int pageSize)
		{
			if (pageNumber < 0 || pageSize < 0)
				return BadRequest("Page number or size is negative");

			var facilities = await logService.GetPage(pageNumber, pageSize);
			return Ok(facilities);
		}
	}

}


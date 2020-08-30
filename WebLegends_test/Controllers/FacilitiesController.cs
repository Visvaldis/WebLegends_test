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
	[Route("api/facilities")]
	[ApiController]
	public class FacilitiesController : ControllerBase
	{
		private readonly IFacilityService facilityService;
		//	IFacilityStatusService statusService;

		public FacilitiesController(IFacilityService _facilityService)
		{
			facilityService = _facilityService;
			//		statusService = _statusService;
		}
		// GET: api/statuses
		[HttpGet]
		public async Task<ActionResult<IEnumerable<FacilityDTO>>> Get()
		{
			try
			{
				var facilities = await facilityService.GetAll();
				return Ok(facilities);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/statuses/5
		[HttpGet("{id}")]
		public async Task<ActionResult<FacilityDTO>> GetById(int id)
		{
			if (id <= 0)
				return BadRequest("Id is negative");
			try
			{
				var facility = await facilityService.Get(id);
				return Ok(facility);
			}
			catch (ValidationException)
			{
				return NotFound();
			}
		}

		// POST api/statuses
		[HttpPost]
		public async Task<ActionResult> Create([FromBody] FacilityDTO item)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState.ValidationState);
			}
			try
			{
				int facilityId = await facilityService.Create(item);
				item.Id = facilityId;

				return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/statuses/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, [FromBody] FacilityDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if ((await facilityService.Exist(id)) == false)
				return NotFound();
			//	int statusId = statusService.GetByName(item.Status.Name).Id;
			item.Id = id;
			//	item.Status.Id = statusId;
			await facilityService.Update(item);
			return Ok();
		}

		// DELETE api/statuses/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			if ((await facilityService.Exist(id)) == false)
				return NotFound();

			await facilityService.Delete(id);
			return NoContent();

		}

		[HttpGet("search/{name}")]
		public async Task<ActionResult<IEnumerable<FacilityDTO>>> GetByName(string name)
		{
			if (name is null || name == "")
				return BadRequest("Name is null");
			try
			{
				var facilities = await facilityService.GetByName(name);

				return Ok(facilities);
			}
			catch (ValidationException)
			{
				return NotFound();
			}
		}

		[HttpGet("status/{name}")]
		public async Task<ActionResult<IEnumerable<FacilityDTO>>> GetByStatus(string name)
		{
			if (name is null || name == "")
				return BadRequest("Name is null");
			try
			{
				var facilities = await facilityService.GetByStatus(name);

				return Ok(facilities);
			}
			catch (ValidationException)
			{
				return NotFound();
			}
		}

		[HttpGet("page")]
		public async Task<ActionResult<IEnumerable<FacilityDTO>>> GetPage(int pageNumber, int pageSize)
		{
			if (pageNumber < 0 || pageSize < 0)
				return BadRequest("Page number or size is negative");

			var facilities = await facilityService.GetPage(pageNumber, pageSize);
			return Ok(facilities);
		}
	}
}

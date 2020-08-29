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
		IFacilityService facilityService;
		public FacilitiesController(IFacilityService service)
		{
			facilityService = service;


		}
		// GET: api/statuses
		[HttpGet]
		public ActionResult<IEnumerable<FacilityDTO>> Get()
		{
			try
			{
				var facilities = facilityService.GetAll();
				return Ok(facilities);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/statuses/5
		[HttpGet("{id}")]
		public ActionResult<FacilityDTO> GetById(int id)
		{
			if (id <= 0)
				return BadRequest("Id is negative");
			try
			{
				var facility = facilityService.Get(id);
				return Ok(facility);
			}
			catch (ValidationException ex)
			{
				return NotFound();
			}
		}

		// POST api/statuses
		[HttpPost]
		public ActionResult Create([FromBody] FacilityDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			try
			{
				int facilityId = facilityService.Add(item);
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
		public ActionResult Update(int id, [FromBody] FacilityDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (!facilityService.Exist(id))
				return NotFound();

			item.Id = id;
			facilityService.Update(item);
			return Ok();
		}

		// DELETE api/statuses/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			if (!facilityService.Exist(id))
				return NotFound();

			facilityService.Delete(id);
			return NoContent();

		}

	}
}

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
	[Route("api/[controller]")]
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

		// POST api/statuses
		[HttpPost]
		public ActionResult Create([FromBody] FacilityLogDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			try
			{
				int logId = logService.Add(item);
				item.Id = logId;

				return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/statuses/5
		[HttpPut("{id}")]
		public ActionResult Update(int id, [FromBody] FacilityLogDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (!logService.Exist(id))
				return NotFound();

			item.Id = id;
			logService.Update(item);
			return Ok();
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

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLegends_test.BLL.DTO;
using WebLegends_test.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLegends_test.Controllers
{
	[Route("api/statuses")]
	[ApiController]
	public class StatusesController : ControllerBase
	{
		IFacilityStatusService statusService;
		public StatusesController(IFacilityStatusService service)
		{
			statusService = service;


		}
		// GET: api/statuses
		[HttpGet]
		public ActionResult<IEnumerable<FacilityStatusDTO>> Get()
		{
			try
			{
				var statuses = statusService.GetAll();
				return Ok(statuses);
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
				var status = statusService.Get(id);
				return Ok(status);
			}
			catch (ValidationException ex)
			{
				return NotFound();
			}
		}

		// POST api/statuses
		[HttpPost]
		public ActionResult Create([FromBody] FacilityStatusDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			try
			{
				int statusId = statusService.Add(item);
				item.Id = statusId;

				return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/statuses/5
		[HttpPut("{id}")]
		public ActionResult Update(int id, [FromBody] FacilityStatusDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (!statusService.Exist(id))
				return NotFound();

			item.Id = id;
			statusService.Update(item);
			return Ok();
		}

		// DELETE api/statuses/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			if (!statusService.Exist(id))
				return NotFound();

			statusService.Delete(id);
			return NoContent();

		}

		[HttpGet("search/{name}")]
		public ActionResult<IEnumerable<FacilityStatusDTO>> GetByName(string name)
		{
			if (name is null || name == "")
				return BadRequest("Name is null");
			try
			{
				var statuses = statusService.GetByName(name);

				return Ok(statuses);
			}
			catch (ValidationException ex)
			{
				return NotFound();
			}
		}
	}
}

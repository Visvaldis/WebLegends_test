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
		private readonly IFacilityStatusService statusService;
		public StatusesController(IFacilityStatusService service)
		{
			statusService = service;


		}
		// GET: api/statuses
		[HttpGet]
		public async Task<ActionResult<IEnumerable<FacilityStatusDTO>>> Get()
		{
			try
			{
				var statuses = await statusService.GetAll();
				return Ok(statuses);
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
				var status = await statusService.Get(id);
				return Ok(status);
			}
			catch (ValidationException)
			{
				return NotFound();
			}
		}

		// POST api/statuses
		[HttpPost]
		public async Task<ActionResult> Create([FromBody] FacilityStatusDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			try
			{
				int statusId = await statusService.Create(item);
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
		public async Task<ActionResult> Update(int id, [FromBody] FacilityStatusDTO item)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if ((await statusService.Exist(id)) == false)
				return NotFound();

			item.Id = id;
			await statusService.Update(item);
			return Ok();
		}

		// DELETE api/statuses/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			if (id < 0)
				return BadRequest("Id is negative");
			if ((await statusService.Exist(id)) == false)
				return NotFound();

			await statusService.Delete(id);
			return NoContent();

		}

		[HttpGet("search/{name}")]
		public async Task<ActionResult<IEnumerable<FacilityStatusDTO>>> GetByName(string name)
		{
			if (name is null || name == "")
				return BadRequest("Name is null");
			try
			{
				var statuses = await statusService.GetByName(name);

				return Ok(statuses);
			}
			catch (ValidationException)
			{
				return NotFound();
			}
		}
	}
}

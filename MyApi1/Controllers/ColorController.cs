using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyApi1.DTOs.Category;
using MyApi1.DTOs.Color;
using MyApi1.Services.Interfaces;

namespace MyApi1.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ColorController : ControllerBase
	{
		private readonly IColorService _service;
		public ColorController(IColorService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Get(int page = 1, int take = 3)
		{
			return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync(page, take));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			if (id < 1) return BadRequest();
			var color = await _service.GetByIdAsync(id);
			if (color == null) return NotFound();
			return StatusCode(StatusCodes.Status200OK, color);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateColorDTO colorDTO)
		{
			if (!await _service.CreateAsync(colorDTO)) return BadRequest();
			return StatusCode(StatusCodes.Status201Created);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromForm] UpdateColorDTO colorDTO)
		{
			if (id < 1) return BadRequest();
			await _service.UpdateAsync(id, colorDTO);
			return StatusCode(StatusCodes.Status204NoContent);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id < 1) return BadRequest();
			await _service.DeleteAsync(id);
			return StatusCode(StatusCodes.Status204NoContent);
		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyApi1.DAL;
using MyApi1.Entity;

namespace MyApi1.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		public AppDbContext _context { get; set; }
		public CategoryController(AppDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var categories = await _context.Categories.ToListAsync();
			return StatusCode(StatusCodes.Status200OK, categories);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			if (id < 1) return BadRequest();
			Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (category == null) return NotFound();
			return StatusCode(StatusCodes.Status200OK, category);
		}
		[HttpPost]
		public async Task<IActionResult> Create(Category category)
		{
			await _context.Categories.AddAsync(category);
			await _context.SaveChangesAsync();	
			return StatusCode(StatusCodes.Status201Created, category);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, string name)
		{
			if (id < 1) return BadRequest();
			Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (category == null) return NotFound();
			category.Name = name;
			await _context.SaveChangesAsync();
			return StatusCode(StatusCodes.Status204NoContent);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id < 1) return BadRequest();
			Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (category == null) return NotFound();
			_context.Categories.Remove(category);
			await _context.SaveChangesAsync();
			return StatusCode(StatusCodes.Status204NoContent);
		}
	}
}

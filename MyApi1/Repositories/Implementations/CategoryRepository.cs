using Microsoft.EntityFrameworkCore;
using MyApi1.Repositories.Interfaces;

namespace MyApi1.Repositories.Implementations
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext context) : base(context) { }
	}
}

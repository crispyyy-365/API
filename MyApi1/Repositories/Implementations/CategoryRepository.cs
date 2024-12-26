using MyApi1.Repositories.Interfaces;

namespace MyApi1.Repositories.Implementations
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(DbContextOptions<AppDbContext> context) : base(context) { }
	}
}

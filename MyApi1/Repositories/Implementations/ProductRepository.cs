using Microsoft.EntityFrameworkCore;
using MyApi1.Repositories.Interfaces;

namespace MyApi1.Repositories.Implementations
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context) { }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi1.Services.Interfaces;
using MyApi1.Repositories.Interfaces;

namespace MyApi1.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Category>> GetAllAsync(int page, int take)
        {
            IEnumerable<Category> categories = await _repository
                .GetAll(skip: (page - 1) * take, take: take)
                .Select(c => new GetCategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count
                })
                .ToListAsync();
            return categories;
        }
    }
}

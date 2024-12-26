using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi1.Services.Interfaces;
using MyApi1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyApi1.DTOs.Category;
using MyApi1.DTOs.Product;

namespace MyApi1.Services.Implementations
{
	public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
		public async Task<bool> CreateAsync(CreateCategoryDTO categoryDTO)
		{
            if (await _repository.AnyAsync(c => c.Name == categoryDTO.Name)) return false;
            await _repository.AddAsync(new Category { Name = categoryDTO.Name });
            await _repository.SaveChangesAsync();
            return true;
		}

		public async Task DeleteAsync(int id)
		{
			Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not Found");
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<GetCategoryDTO>> GetAllAsync(int page, int take)
        {
            IEnumerable<GetCategoryDTO> categories = await _repository
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
		public async Task<GetCategoryDetailDTO> GetByIdAsync(int id)
		{
            Category category = await _repository.GetByIdAsync(id, nameof(Category.Products));
            if (category == null) throw new Exception("Not Found");
            GetCategoryDetailDTO categoryDTO = new()
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products
                .Select(p => new GetProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList()
            };
            return categoryDTO;
		}
		public async Task UpdateAsync(int id, UpdateCategoryDTO categoryDTO)
		{
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not Found");
            if (await _repository.AnyAsync(c => c.Name == categoryDTO.Name && c.Id != id)) throw new Exception("Already exists");
            category.Name = categoryDTO.Name;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
		}
	}
}

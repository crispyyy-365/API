using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi1.DTOs.Color;
using MyApi1.Repositories.Interfaces;

namespace MyApi1.Services.Implementations
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _repository;
        public CategoryService(IColorRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(CreateColorDTO colorDTO)
        {
            if (await _repository.AnyAsync(c => c.Name == colorDTO.Name)) return false;
            await _repository.AddAsync(new Color { Name = colorDTO.Name });
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color == null) throw new Exception("Not Found");
            _repository.Delete(color);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetColorDTO>> GetAllAsync(int page, int take)
        {
            IEnumerable<GetColorDTO> colors = await _repository
                .GetAll(skip: (page - 1) * take, take: take)
                .Select(c => new GetColorDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count
                })
                .ToListAsync();
            return colors;
        }
        public async Task<GetColorDetailDTO> GetByIdAsync(int id)
        {
            Color color = await _repository.GetByIdAsync(id, nameof(Color.Products));
            if (color == null) throw new Exception("Not Found");
            GetColorDetailDTO colorDTO = new()
            {
                Id = color.Id,
                Name = color.Name,
                Products = color.Products
                .Select(p => new GetProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList()
            };
            return colorDTO;
        }
        public async Task UpdateAsync(int id, UpdateColorDTO colorDTO)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color == null) throw new Exception("Not Found");
            if (await _repository.AnyAsync(c => c.Name == colorDTO.Name && c.Id != id)) throw new Exception("Already exists");
            color.Name = colorDTO.Name;
            _repository.Update(color);
            await _repository.SaveChangesAsync();
        }
    }
}

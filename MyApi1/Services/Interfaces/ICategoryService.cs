using MyApi1.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi1.Services.Interfaces
{
	public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDTO>> GetAllAsync(int page, int take);
        Task<GetCategoryDetailDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCategoryDTO categoryDTO);
        Task UpdateAsync(int id, UpdateCategoryDTO categoryDTO);
        Task DeleteAsync(int id);
    }
}

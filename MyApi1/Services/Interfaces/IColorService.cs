using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi1.DTOs.Color;

namespace MyApi1.Services.Interfaces
{
    public interface IColorService
    {
        Task<IEnumerable<GetColorDTO>> GetAllAsync(int page, int take);
        Task<GetColorDetailDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateColorDTO categoryDTO);
        Task UpdateAsync(int id, UpdateColorDTO categoryDTO);
        Task DeleteAsync(int id);
    }
}

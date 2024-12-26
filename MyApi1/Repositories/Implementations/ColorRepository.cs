using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi1.Repositories.Interfaces;

namespace MyApi1.Repositories.Implementations
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}

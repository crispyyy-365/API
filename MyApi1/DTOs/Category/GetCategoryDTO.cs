using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi1.DTOs.Category
{
	public record GetCategoryDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ProductCount { get; set; }
	}
}

using MyApi1.DTOs.Product;

namespace MyApi1.DTOs.Category
{
	public record GetCategoryDetailDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<GetProductDTO> Products { get; set; }
	}
}

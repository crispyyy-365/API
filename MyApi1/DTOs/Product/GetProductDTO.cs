using System.Security.Principal;

namespace MyApi1.DTOs.Product
{
	public record GetProductDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}

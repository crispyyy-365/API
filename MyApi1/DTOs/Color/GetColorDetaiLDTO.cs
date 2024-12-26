using MyApi1.DTOs.Product;

namespace MyApi1.DTOs.Color
{
	public class GetColorDetaiLDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<GetProductDTO> Products { get; set; }
	}
}

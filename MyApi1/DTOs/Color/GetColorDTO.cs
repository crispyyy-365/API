namespace MyApi1.DTOs.Color
{
	public record GetColorDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ProductCount { get; set; }
	}
}

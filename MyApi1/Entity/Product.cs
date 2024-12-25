using MyApi1.Entity.Base;

namespace MyApi1.Entity
{
	public class Product : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}

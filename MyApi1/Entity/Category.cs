using MyApi1.Entity.Base;

namespace MyApi1.Entity
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}

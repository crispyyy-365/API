using MyApi1.Entity.Base;
using System.Linq.Expressions;

namespace MyApi1.Repositories.Interfaces
{
	public interface IRepository<T> where T : BaseEntity, new()
	{
		IQueryable<T> GetAll(
			Expression<Func<T, bool>>? expression = null,
			Expression<Func<T, object>>? orderExpression = null,
			bool isDescending = false,
			bool isTracking = false,
			int skip = 0,
			int take = 0,
			params string[]? includes
			);
		Task<T> GetByIdAsync(int id);
		Task AddAsync(T entity);
		void Delete(T entity);
		void Update(T entity);
		Task<int> SaveChangesAsync();
	}
}

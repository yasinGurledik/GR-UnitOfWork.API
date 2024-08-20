using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GR_UnitOfWork.Domain.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		IEnumerable<T> GetAllAsync();
		Task<List<T>> GetListAsync();
		IQueryable<T> GetAllIQAsync();
		IQueryable<T> Where(Expression<Func<T,bool>> predicate);
		IEnumerable<T> Find(Expression<Func<T,bool>> expression);
		Task AddAsync(T entity);	
		Task AddRangeAsync(IEnumerable<T> entities);
		void UpdateAsync(T entity);
		void Remove(T entity);	
		void RemoveRange(IEnumerable<T> entities);	

	}
}

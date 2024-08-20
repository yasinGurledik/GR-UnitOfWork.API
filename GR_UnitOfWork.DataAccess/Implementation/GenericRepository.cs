using GR_UnitOfWork.DataAccess.Context;
using GR_UnitOfWork.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GR_UnitOfWork.DataAccess.Implementation
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected UnitDbContext _context;
		private DbSet<T> _dbSet;
		public GenericRepository(UnitDbContext context)
		{
			_context = context;
			_dbSet=_context.Set<T>();	
		}

		public async Task AddAsync(T entity)
		{
			//await _context.Set<T>().Add(entity);
			await _dbSet.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await _dbSet.AddRangeAsync(entities);
		}

		public  IEnumerable<T> GetAllAsync()
		{
			return  _dbSet.ToList();
		}	
		public async Task<List<T>> GetListAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public IQueryable<T> GetAllIQAsync()
		{
			return _dbSet.AsNoTracking().AsQueryable();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void Remove(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_dbSet.RemoveRange(entities);
		}

		public void UpdateAsync(T entity)
		{
			 _dbSet.Update(entity);
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Where(predicate);
		}
		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return _dbSet.Where(expression);
		}
	}
}

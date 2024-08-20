using GR_UnitOfWork.DataAccess.Context;
using GR_UnitOfWork.Domain.Entities;
using GR_UnitOfWork.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR_UnitOfWork.DataAccess.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
		protected UnitDbContext _context;
		public UnitOfWork(UnitDbContext context)
		{
			_context = context;
			Actor = new ActorRepository(_context);
			Movie = new MovieRepository(_context);
			Biography = new BiographyRepository(_context);
			Genre = new GenreRepository(_context);
		}

		public IActorrepository Actor { get; private set; }

		public IMovieRepository Movie { get; private set; }

		public IBiographyrepository Biography { get; private set; }

		public IGenreRepository Genre { get; private set; }

		public int Save()
		{
			return _context.SaveChanges();	
		}
		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}
		public void Dispose() { 
			_context.Dispose();	
		}
	}
}

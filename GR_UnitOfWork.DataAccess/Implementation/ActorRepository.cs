using GR_UnitOfWork.DataAccess.Context;
using GR_UnitOfWork.Domain.Entities;
using GR_UnitOfWork.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR_UnitOfWork.DataAccess.Implementation
{
	public class ActorRepository : GenericRepository<Actor>, IActorrepository
	{
		public ActorRepository(UnitDbContext context) : base(context)
		{
		}

		public async Task<List<Actor>> GetActorsWithMovies()
		{

			return await _context.Actors.Include(x => x.Movies).ToListAsync();
			
		}
	}
}

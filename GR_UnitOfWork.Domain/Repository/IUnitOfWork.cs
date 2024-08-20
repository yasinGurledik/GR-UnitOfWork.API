using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR_UnitOfWork.Domain.Repository
{
	public interface IUnitOfWork:IDisposable
	{
		IActorrepository Actor { get; }
		IMovieRepository Movie { get; }
		IBiographyrepository Biography { get; }	
		IGenreRepository Genre { get; }
		int Save();
		Task<int> SaveAsync();
	}
}

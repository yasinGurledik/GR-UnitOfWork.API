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
	public class BiographyRepository : GenericRepository<Biography>, IBiographyrepository
	{
		public BiographyRepository(UnitDbContext context) : base(context)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GR_UnitOfWork.Domain.Entities
{
	public class Biography
	{
		public int Id { get; set; }
		public string Description { get; set; } = string.Empty;
		public int ActorId { get; set; }
		public Actor? Actor { get; set; }
    }
}

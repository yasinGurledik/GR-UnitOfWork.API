using GR_UnitOfWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GR_UnitOfWork.DataAccess.Context
{
	public class UnitDbContext : DbContext
	{
		private readonly IConfiguration _configuration;
		public UnitDbContext(DbContextOptions<UnitDbContext> options, IConfiguration configuration) : base(options)
		{
			_configuration = configuration;
		}

		public DbSet<Actor> Actors { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Biography> Biographies { get; set; }
		public DbSet<Genre> Genres { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Actor>().HasData(
				new Actor { Id = 1, FirstName = "Yasin", LastName = "Gür" },
				new Actor { Id = 2, FirstName = "Jone", LastName = "Doe" },
				new Actor { Id = 3, FirstName = "Van", LastName = "Domme" }

				);

			modelBuilder.Entity<Movie>().HasData(
				new Movie { Id = 1, Name = "Wakanda Forever", Description = "Box Office we comming", ActorId = 1 },
				new Movie { Id = 2, Name = "Forest Gamp", Description = "Forest Gamp", ActorId = 2 },
				new Movie { Id = 3, Name = "Camping", Description = "Camping", ActorId = 3 },
				new Movie { Id = 4, Name = "Spiderman", Description = "Spiderman", ActorId = 1 },
				new Movie { Id = 5, Name = "Matrix", Description = "Matrix", ActorId = 2 }

				);
			//modelBuilder.Entity<Biography>().HasData(
			//new Biography { Id = 1, Description = "Box Office we comming", ActorId = 1 },
			//new Biography { Id = 2, Description = "Forest Gamp", ActorId = 2 },
			//new Biography { Id = 3, Description = "Camping", ActorId = 3 }

			//);

			//modelBuilder.Entity<Genre>().HasData(
			//	new Genre { Id = 1, Name = "Wakanda Forever" },
			//	new Genre { Id = 2, Name = "Forest Gamp", },
			//	new Genre { Id = 3, Name = "Camping", }

			//	);
			//base.OnModelCreating(modelBuilder);
		}
	}
}

using GR_UnitOfWork.Domain.Entities;
using GR_UnitOfWork.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GR_UnitOfWork.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActorController : ControllerBase
	{
		public IUnitOfWork _unitOfWork;
		public ActorController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var actors=_unitOfWork.Actor.GetAllIQAsync().ToList();
			return Ok(actors);
		}
		[HttpGet("GetWithMovies")]
		public async Task<ActionResult> GetWithMovies()
		{
			var actors=await _unitOfWork.Actor.GetActorsWithMovies();
			return Ok(actors);
		}
		[HttpPost()]
		public async Task<ActionResult> Add(Actor actor)
		{
			await _unitOfWork.Actor.AddAsync(actor);
			var result=await _unitOfWork.SaveAsync();

			return Ok(result);
		}
	}
}

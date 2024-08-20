using GR_UnitOfWork.Domain.Entities;
using GR_UnitOfWork.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GR_UnitOfWork.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		public IUnitOfWork _unitOfWork;
		public MovieController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var actors=_unitOfWork.Movie.GetAllIQAsync().ToList();
			return Ok(actors);
		}

		[HttpPost()]
		public async Task<ActionResult> Add(Movie movie)
		{
			await _unitOfWork.Movie.AddAsync(movie);
			var result=await _unitOfWork.SaveAsync();

			return Ok(result);
		}
	}
}

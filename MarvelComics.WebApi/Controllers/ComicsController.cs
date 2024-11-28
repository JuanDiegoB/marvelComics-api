using MarvelComics.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MarvelComics.WebApi.Controllers
{
	[EnableCors("PermitirAngular")]
	[ApiController]
	[Route("api/[controller]")]
	public class ComicsController : ControllerBase
	{
		private readonly IMarvelService _marvelService;

		public ComicsController(IMarvelService marvelService)
		{
			_marvelService = marvelService;
		}

		[HttpGet]
		public async Task<IActionResult> GetComics()
		{
			var comics = await _marvelService.GetComicsAsync();
			return Ok(comics);
		}
	}
}

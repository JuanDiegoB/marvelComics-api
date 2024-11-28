using MarvelComics.Application.Commands;
using MarvelComics.Application.DTOs;
using MarvelComics.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MarvelComics.WebApi.Controllers
{
	[EnableCors("PermitirAngular")]
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		// private readonly IMediator _mediator;
		
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserDto userDto)
		{
			try
			{
				await _userService.RegisterUserAsync(userDto);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}
	}
}

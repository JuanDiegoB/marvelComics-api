using MarvelComics.Application.DTOs;
using MarvelComics.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarvelComics.WebApi.Controllers
{
//	[EnableCors("PermitirAngular")]
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			try
			{
				var response = await _authService.LoginAsync(loginDto);
				return Ok(response);
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(new { Error = ex.Message });
			}
		}

		[HttpPost("refresh")]
		public async Task<IActionResult> RefreshToken([FromQuery] string refreshToken)
		{
			try
			{
				var response = await _authService.RefreshTokenAsync(refreshToken);
				return Ok(response);
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(new { Error = ex.Message });
			}
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
			await _authService.LogoutAsync(userId);
			return Ok(new { Message = "Sesión cerrada con éxito." });
		}
	}
}

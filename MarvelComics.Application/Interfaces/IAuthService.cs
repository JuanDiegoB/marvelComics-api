using MarvelComics.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Application.Interfaces
{
	public interface IAuthService
	{
		Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
		Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
		Task LogoutAsync(Guid userId);
	}
}

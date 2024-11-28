using MarvelComics.Application.DTOs;
using MarvelComics.Application.Interfaces;
using MarvelComics.Domain.Entities;
using MarvelComics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MarvelComics.Application.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _configuration;
		private readonly PasswordHasher<User> _passwordHasher;

		public AuthService(IUserRepository userRepository, IConfiguration configuration)
		{
			_userRepository = userRepository;
			_configuration = configuration;
			_passwordHasher = new PasswordHasher<User>();
		}

		public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
		{
			var user = await _userRepository.GetByEmailAsync(loginDto.Email);
			if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
				throw new UnauthorizedAccessException("Credenciales inválidas.");

			return await GenerateTokens(user);
		}

		public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
		{
			var user = await _userRepository.GetByRefreshTokenAsync(refreshToken);
			if (user == null || !user.IsRefreshTokenValid(refreshToken))
				throw new UnauthorizedAccessException("Token de renovación inválido.");

			return await GenerateTokens(user);
		}

		public async Task LogoutAsync(Guid userId)
		{
			var user = await _userRepository.GetByIdAsync(userId);
			if (user == null) throw new KeyNotFoundException("Usuario no encontrado.");

			await _userRepository.UpdateAsync(user);
		}

		private string GenerateJwtToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "DefaultSuperSecretKey"));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expiry = DateTime.UtcNow.AddHours(1); // Expira en 1 hora

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: expiry,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private async Task<AuthResponseDto> GenerateTokens(User user)
		{
			var token = GenerateJwtToken(user);
			var refreshToken = GenerateRefreshToken();

			user.SetRefreshToken(refreshToken, DateTime.UtcNow.AddDays(7));
			await _userRepository.UpdateAsync(user);

			return new AuthResponseDto
			{
				User = new UserDto
				{
					Name = user.Name,
					Email = user.Email,
					Identification = user.Identification,
					RefreshToken = user.RefreshToken
				},
				Token = token,
				RefreshToken = refreshToken
			};
		}

		private string GenerateRefreshToken()
		{
			return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
		}
	}
}

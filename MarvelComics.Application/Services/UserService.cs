using MarvelComics.Application.DTOs;
using MarvelComics.Application.Interfaces;
using MarvelComics.Domain.Entities;
using MarvelComics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task RegisterUserAsync(UserDto userDto)
		{
			var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
			if (existingUser != null)
				throw new InvalidOperationException("El usuario ya está registrado.");

			userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

			var user = new User(userDto.Name, userDto.Identification, userDto.Email, userDto.Password);
			await _userRepository.AddAsync(user);
		}
	}
}

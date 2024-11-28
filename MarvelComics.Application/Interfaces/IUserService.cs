using MarvelComics.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Application.Interfaces
{
	public interface IUserService
	{
		Task RegisterUserAsync(UserDto userDto);
	}
}

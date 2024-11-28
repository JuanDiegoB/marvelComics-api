using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class AuthResponseDto
	{
		public UserDto User { get; set; }
		public string Token { get; set; }
		public string RefreshToken { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Domain.Entities
{
	public class User
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Identification { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
		public List<Comic> FavoriteComics { get; private set; } = [];
		public string? RefreshToken { get; private set; }
		public DateTime? RefreshTokenExpiryTime { get; private set; }

		private User() { }

		public User(string name, string identification, string email, string password)
        {
			Id = Guid.NewGuid();
			Name = name;
			Identification = identification;
			Email = email;
			Password = password;
		}

		public void SetRefreshToken(string refreshToken, DateTime expiryTime)
		{
			RefreshToken = refreshToken;
			RefreshTokenExpiryTime = expiryTime;
		}

		public bool IsRefreshTokenValid(string token) =>
			RefreshToken == token && RefreshTokenExpiryTime > DateTime.UtcNow;
	}
}

using MarvelComics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Domain.Interfaces
{
	public interface IUserRepository
	{
		Task AddAsync(User user);
		Task<User?> GetByEmailAsync(string email);
		Task<User?> GetByIdAsync(Guid id);
		Task<User?> GetByRefreshTokenAsync(string refreshToken);
		Task UpdateAsync(User user);
	}
}

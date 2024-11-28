using MarvelComics.Domain.Entities;
using MarvelComics.Domain.Interfaces;
using MarvelComics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _databaseContext;

		public UserRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task AddAsync(User user)
		{
			await _databaseContext.Users.AddAsync(user);
			await _databaseContext.SaveChangesAsync();
		}

		public async Task<User?> GetByEmailAsync(string email)
		{
			return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<User?> GetByIdAsync(Guid id)
		{
			return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
		{
			return await _databaseContext.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
		}

		public async Task UpdateAsync(User user)
		{
			_databaseContext.Users.Update(user);
			await _databaseContext.SaveChangesAsync();
		}
	}
}

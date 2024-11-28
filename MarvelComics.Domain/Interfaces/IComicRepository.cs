using MarvelComics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Domain.Interfaces
{
	public interface IComicRepository
	{
		Task AddFavoriteComic(Comic comic);

		Task DeleteFavoriteComic(int id);

		Task GetFavoriteComics(Guid userId);
	}
}

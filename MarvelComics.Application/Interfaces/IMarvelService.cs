using MarvelComics.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Domain.Interfaces
{
	public interface IMarvelService
	{
		Task<IEnumerable<MarvelResult>?> GetComicsAsync();
	}
}

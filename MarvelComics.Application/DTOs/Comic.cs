using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class Comic
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ThumbnailUrl { get; set; }
	}
}

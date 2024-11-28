using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Domain.Entities
{
	public class Comic
	{
		public int Id { get; private set; }
		public string Title { get; private set; }
		public string Description { get; private set; }
		public string ThumbnailUrl { get; private set; }
		public Guid UserId { get; private set; }

		public Comic(int id, string title, string description, string thumbnailUrl, Guid userId)
		{
			Id = id;
			Title = title;
			Description = description;
			ThumbnailUrl = thumbnailUrl;
			UserId = userId;
		}
	}
}

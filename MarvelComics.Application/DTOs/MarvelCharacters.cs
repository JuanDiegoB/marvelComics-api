using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class MarvelCharacters
	{
		[JsonPropertyName("available")]
		public int? Available { get; set; }

		[JsonPropertyName("collectionURI")]
		public string? CollectionURI { get; set; }

		[JsonPropertyName("items")]
		public List<MarvelItem>? Items { get; set; }

		[JsonPropertyName("returned")]
		public int? Returned { get; set; }
	}
}

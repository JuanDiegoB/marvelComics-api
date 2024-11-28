using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class MarvelVariant
	{
		[JsonPropertyName("resourceURI")]
		public string? ResourceURI { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }
	}
}

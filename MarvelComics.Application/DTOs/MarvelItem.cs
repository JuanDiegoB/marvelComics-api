using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class MarvelItem
	{
		[JsonPropertyName("resourceURI")]
		public string? ResourceURI { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("role")]
		public string? Role { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }
	}
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class MarvelUrl
	{
		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("url")]
		public string? Url { get; set; }
	}
}

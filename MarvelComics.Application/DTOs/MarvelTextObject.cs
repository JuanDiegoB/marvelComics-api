using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class MarvelTextObject
	{
		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("language")]
		public string? Language { get; set; }

		[JsonPropertyName("text")]
		public string? Text { get; set; }
	}
}

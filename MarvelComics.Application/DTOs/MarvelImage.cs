using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class MarvelImage
	{
		[JsonPropertyName("path")]
		public string? Path { get; set; }

		[JsonPropertyName("extension")]
		public string? Extension { get; set; }
	}
}

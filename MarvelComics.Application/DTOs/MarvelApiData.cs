using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.DTOs
{
	public class MarvelApiData
	{
		[JsonPropertyName("offset")]
		public int? Offset { get; set; }

		[JsonPropertyName("limit")]
		public int? Limit { get; set; }

		[JsonPropertyName("total")]
		public int? Total { get; set; }

		[JsonPropertyName("count")]
		public int? Count { get; set; }

		[JsonPropertyName("results")]
		public List<MarvelResult>? Results { get; set; }
	}
}

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarvelComics.Application.DTOs
{
	public class MarvelResult
	{
		[JsonPropertyName("id")]
		public int? Id { get; set; }

		[JsonPropertyName("digitalId")]
		public int? DigitalId { get; set; }

		[JsonPropertyName("title")]
		public string? Title { get; set; }

		[JsonPropertyName("issueNumber")]
		public int? IssueNumber { get; set; }

		[JsonPropertyName("variantDescription")]
		public string? VariantDescription { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		//[JsonPropertyName("modified")]
		//public DateTime? Modified { get; set; }

		[JsonPropertyName("isbn")]
		public string? Isbn { get; set; }

		[JsonPropertyName("upc")]
		public string? Upc { get; set; }

		[JsonPropertyName("diamondCode")]
		public string? DiamondCode { get; set; }

		[JsonPropertyName("ean")]
		public string? Ean { get; set; }

		[JsonPropertyName("issn")]
		public string? Issn { get; set; }

		[JsonPropertyName("format")]
		public string? Format { get; set; }

		[JsonPropertyName("pageCount")]
		public int? PageCount { get; set; }

		[JsonPropertyName("textObjects")]
		public List<MarvelTextObject>? TextObjects { get; set; }

		[JsonPropertyName("resourceURI")]
		public string? ResourceURI { get; set; }

		[JsonPropertyName("urls")]
		public List<MarvelUrl>? Urls { get; set; }

		[JsonPropertyName("series")]
		public MarvelSeries? Series { get; set; }

		[JsonPropertyName("variants")]
		public List<MarvelVariant>? Variants { get; set; }

		[JsonPropertyName("collections")]
		public List<MarvelVariant>? Collections { get; set; }

		[JsonPropertyName("collectedIssues")]
		public List<MarvelVariant>? CollectedIssues { get; set; }

		//[JsonPropertyName("dates")]
		//public List<MarvelDate>? Dates { get; set; }

		[JsonPropertyName("prices")]
		public List<MarvelPrice>? Prices { get; set; }

		[JsonPropertyName("thumbnail")]
		public MarvelThumbnail? Thumbnail { get; set; }

		[JsonPropertyName("images")]
		public List<MarvelImage>? Images { get; set; }

		[JsonPropertyName("creators")]
		public MarvelCreators? Creators { get; set; }

		[JsonPropertyName("characters")]
		public MarvelCharacters? Characters { get; set; }

		[JsonPropertyName("stories")]
		public MarvelStories? Stories { get; set; }

		[JsonPropertyName("events")]
		public MarvelEvents? Events { get; set; }
	}
}

using MarvelComics.Application.DTOs;
using MarvelComics.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MarvelComics.Infrastructure.Services
{
	public class MarvelService : IMarvelService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;

		public MarvelService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}

		public async Task<IEnumerable<MarvelResult>?> GetComicsAsync()
		{
			var baseUrl = _configuration["MarvelApi:BaseUrl"];
			var publicKey = _configuration["MarvelApi:PublicKey"];
			var privateKey = _configuration["MarvelApi:PrivateKey"];

			if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(publicKey) || string.IsNullOrEmpty(privateKey))
			{
				throw new InvalidOperationException("Marvel API configuration is missing.");
			}

			// Generar el timestamp y hash
			var timeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
			var hash = GenerateHash(timeStamp, privateKey, publicKey);

			// Construir la URL
			var url = $"{baseUrl}/comics?ts={timeStamp}&apikey={publicKey}&hash={hash}";

			// Hacer la solicitud
			var response = await _httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
			{
				throw new HttpRequestException($"Marvel API responded with status code: {response.StatusCode}");
			}

			// Procesar la respuesta
			var jsonResponse = await response.Content.ReadAsStringAsync();
			var data = JsonSerializer.Deserialize<MarvelApiResponse>(jsonResponse);

			// Mapear los resultados
			//return data?.Data.Results.Select(c => new Comic
			//{
			//	Id = c.Id,
			//	Title = c.Title,
			//	Description = c.Description,
			//	ThumbnailUrl = $"{c.Thumbnail.Path}.{c.Thumbnail.Extension}"
			//}) ?? Enumerable.Empty<Comic>();

			if (data != null && data.Data != null) {
				return data.Data.Results;
			}
			return [];
			
		}

		private static string GenerateHash(string timeStamp, string privateKey, string publicKey)
		{
			var toHash = $"{timeStamp}{privateKey}{publicKey}";
			using var md5 = MD5.Create();
			var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(toHash));
			return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
		}
	}
}

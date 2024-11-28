using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.WebApi.Middleware
{
	public class AuthenticationMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<AuthenticationMiddleware> _logger;
		private readonly IConfiguration _configuration;

		public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger, IConfiguration configuration)
		{
			_next = next;
			_logger = logger;
			_configuration = configuration;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			// Excluir rutas públicas (si es necesario)
			var path = context.Request.Path;
			if (path.StartsWithSegments("/api/auth/login") ||
				path.StartsWithSegments("/api/users/register") ||
				path.StartsWithSegments("/swagger"))
			{
				await _next(context);
				return;
			}

			// Verificar si el encabezado de autorización está presente
			var authHeader = context.Request.Headers["Authorization"].ToString();
			if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
			{
				_logger.LogWarning("Token no proporcionado o inválido.");
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				await context.Response.WriteAsync("Unauthorized: Token not provided or invalid.");
				return;
			}

			var token = authHeader["Bearer ".Length..].Trim();

			try
			{
				// Validar el token
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = _configuration["Jwt:Issuer"],
					ValidAudience = _configuration["Jwt:Audience"],
					ValidateLifetime = true
				}, out _);

				await _next(context);
			}
			catch (SecurityTokenException ex)
			{
				_logger.LogError($"Token inválido: {ex.Message}");
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				await context.Response.WriteAsync("Unauthorized: Token validation failed.");
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error inesperado durante la autenticación: {ex.Message}");
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await context.Response.WriteAsync("Internal Server Error: Authentication failed.");
			}
		}
	}
}

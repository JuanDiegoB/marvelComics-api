﻿using MarvelComics.Domain.Interfaces;
using MarvelComics.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarvelComics.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpClient<IMarvelService, MarvelService>();
			return services;
		}
	}
}

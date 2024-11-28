using MarvelComics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Infrastructure.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);
			builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
			builder.Property(u => u.Identification).IsRequired().HasMaxLength(20);
			builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
			builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
		}

	}
}

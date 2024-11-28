using MarvelComics.Domain.Entities;
using MarvelComics.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Application.Commands
{
	public class RegisterUserCommandHandler // : IRequestHandler<RegisterUserCommand, Guid>
	{
		private readonly IUserRepository _userRepository;

		public RegisterUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		//public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		//{
		//	// Validar si el usuario ya existe
		//	var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
		//	if (existingUser != null)
		//		throw new InvalidOperationException("Username is already taken.");

		//	// Crear el usuario
		//	var password = new Password(request.Password);
		//	var user = new User(request.Username, password);

		//	// Guardar en la base de datos
		//	await _userRepository.AddAsync(user);

		//	return user.Id;
		//}
	}
}

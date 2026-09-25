using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, ResultViewModel>
    {
        private readonly DataContext _context;
        private readonly IPasswordHasher<User> _passwordHasher; 

        public RegisterHandler(DataContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResultViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.Code, request.Login, string.Empty, true);
                var userExists = await _context.Users.AnyAsync(u => u.Login == request.Login || u.Code == request.Code, cancellationToken);

                if (userExists)
                {
                    return ResultViewModel.Error("Já existe um usuário cadastrado com este login ou código.");
                }
                string hashedPassword = _passwordHasher.HashPassword(user, request.PasswordHash);

                var secureUser = new User(request.Code, request.Login, hashedPassword, true);

                await _context.Users.AddAsync(secureUser, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Usuário registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error($"Erro ao registrar usuário: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}

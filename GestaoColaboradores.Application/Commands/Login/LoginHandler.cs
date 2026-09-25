using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Auth;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, ResultViewModel<string>>
    {
        private readonly DataContext _context;
        private readonly TokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher; 

        public LoginHandler(DataContext context, TokenService tokenService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResultViewModel<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(t => t.Login == request.Login, cancellationToken);
            if (user == null)
            {
                return ResultViewModel<string>.Error("Usuário ou senha inválidos.");
            }
            var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.PasswordHash);

            if (passwordVerification == PasswordVerificationResult.Failed)
            {
                return ResultViewModel<string>.Error("Usuário ou senha inválidos.");
            }
            if (!user.IsActive)
            {
                return ResultViewModel<string>.Error("Este usuário está inativo.");
            }

            var token = _tokenService.GenerateToken(user);

            return ResultViewModel<string>.Success(token, "Login efetuado com sucesso!");
        }
    }
}

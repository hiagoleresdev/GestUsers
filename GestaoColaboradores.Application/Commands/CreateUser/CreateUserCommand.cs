using GestaoColaboradores.Application.Models;
using GestaoColaboradores.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ResultViewModel>
    {
        public CreateUserCommand(string code, string login, string passwordHash, bool isActive)
        {
            Code = code;
            Login = login;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }

        public string Code { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}

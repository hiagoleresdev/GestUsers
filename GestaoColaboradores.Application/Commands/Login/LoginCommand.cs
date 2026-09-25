using GestaoColaboradores.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.Login
{
    public record LoginCommand(string Login, string PasswordHash) : IRequest<ResultViewModel<string>>;
}

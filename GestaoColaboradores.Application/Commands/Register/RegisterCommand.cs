using GestaoColaboradores.Core.Entities;
using MediatR;

namespace GestaoColaboradores.Application.Commands.Register
{
    public class RegisterCommand : IRequest<ResultViewModel>
    {
        public string Code { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}

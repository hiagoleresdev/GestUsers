using GestaoColaboradores.Core.Entities;
using MediatR;

namespace GestaoColaboradores.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}

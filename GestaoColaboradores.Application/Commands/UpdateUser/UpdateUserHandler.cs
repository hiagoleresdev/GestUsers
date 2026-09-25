using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly DataContext _context;
        private readonly IPasswordHasher<User> _passwordHasher; // <-- 1. Adicione a dependência do hasher

        public UpdateUserHandler(DataContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher; // <-- 2. Atribua no construtor
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

                if (user == null)
                {
                    return ResultViewModel.Error("Usuário não encontrado.");
                }

                string passwordToSave = user.PasswordHash;

                if (!string.IsNullOrWhiteSpace(request.PasswordHash))
                {
                    passwordToSave = _passwordHasher.HashPassword(user, request.PasswordHash);
                }

                user.Update(user.Code, user.Login, passwordToSave, request.IsActive);

                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Usuário atualizado com sucesso!");
            }
            catch(Exception ex)
            {
                return ResultViewModel.Error($"Erro ao atualizar usuário: {ex.InnerException?.Message ?? ex.Message}");
            }
            
        }
    }
}

using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly DataContext _context;

        public DeleteUserHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users.FirstOrDefaultAsync(t => t.Id == request.Id);

                if (users == null)
                    return ResultViewModel.Error("Usuário não encontrado.");

                _context.Users.Remove(users);
                await _context.SaveChangesAsync();

                return ResultViewModel.Success("Usuário excluído com sucesso!");
            } catch (Exception ex)
            {
                return ResultViewModel.Error($"Erro ao excluir usuário: {ex.InnerException?.Message ?? ex.Message}");
            }
           
        }
    }
}

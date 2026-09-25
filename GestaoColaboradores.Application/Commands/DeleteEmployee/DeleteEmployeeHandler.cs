using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Commands.DeleteEmployee
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ResultViewModel>
    {
        private readonly DataContext _context;

        public DeleteEmployeeHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(t => t.Id == request.Id);

                if (employee == null)
                    return ResultViewModel.Error("Funcionário não encontrado.");

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return ResultViewModel.Success("Funcionário excluído com sucesso!");
            }
            catch(Exception ex)
            {
                return ResultViewModel.Error($"Erro ao excluir funcionário: {ex.InnerException?.Message ?? ex.Message}");
            }
            
        }
    }
}

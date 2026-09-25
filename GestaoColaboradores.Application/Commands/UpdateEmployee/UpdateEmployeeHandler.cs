using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Commands.UpdateEmployee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ResultViewModel>
    {
        private readonly DataContext _context;

        public UpdateEmployeeHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
                if (employee == null)
                    return ResultViewModel.Error("Colaborador não encontrado.");

                // Valida se a nova unidade existe e está ativa
                var unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == request.UnitId, cancellationToken);

                if (unit == null)
                    return ResultViewModel.Error("Unidade não encontrada.");
                if (!unit.IsActive)
                    return ResultViewModel.Error("Não é possível mover o colaborador para uma unidade inativa.");

                employee.Update(request.Name, request.UnitId);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Colaborador atualizado com sucesso!");
            }
            catch(Exception ex)
            {
                return ResultViewModel.Error($"Erro ao atualizar colaborador: {ex.InnerException?.Message ?? ex.Message}");
            }
            
        }
    }
}

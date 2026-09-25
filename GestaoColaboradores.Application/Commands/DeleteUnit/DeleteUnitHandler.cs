using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.DeleteUnit
{
    public class DeleteUnitHandler : IRequestHandler<DeleteUnitCommand, ResultViewModel>
    {
        private readonly DataContext _context;

        public DeleteUnitHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var unit = await _context.Units
                 .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (unit == null)
                    return ResultViewModel.Error("Unidade não encontrado.");

                var hasEmployees = await _context.Employees.AnyAsync(e => e.UnitId == request.Id, cancellationToken);
                if (hasEmployees)
                    return ResultViewModel.Error("Não é possível excluir esta unidade pois existem colaboradores vinculados a ela.");

                _context.Units.Remove(unit);

                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Unidade excluída com sucesso!");
            }
            catch(Exception ex)
            {
                return ResultViewModel.Error($"Erro ao excluir unidade: {ex.InnerException?.Message ?? ex.Message}");
            }
            
        }
    }
}

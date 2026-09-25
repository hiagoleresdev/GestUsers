using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.InactivateUnit
{
    public class InactivateUnitHandler : IRequestHandler<InactivateUnitCommand, ResultViewModel>
    {
        private readonly DataContext _context;

        public InactivateUnitHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(InactivateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (unit == null)
                return ResultViewModel.Error("Unidade não encontrada.");

            unit.Inactivate();

            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
    }
}

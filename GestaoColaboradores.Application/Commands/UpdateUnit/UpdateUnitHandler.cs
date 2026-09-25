using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.UpdateUnit
{
    public class UpdateUnitHandler : IRequestHandler<UpdateUnitCommand, ResultViewModel>
    {

        private readonly DataContext _context;

        public UpdateUnitHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var unit = await _context.Units
                 .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

                if (unit == null)
                {
                    return ResultViewModel.Error("Unidade não encontrado.");
                }

                unit.Update(request.Code, request.Name, request.IsActive);

                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Unidade atualizada com sucesso!");
            }
            catch(Exception ex)
            {
                return ResultViewModel.Error($"Erro ao atualizar unidade: {ex.InnerException?.Message ?? ex.Message}");
            }
            
        }
    }
}

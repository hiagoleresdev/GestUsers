using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.CreateUnit
{
    public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, ResultViewModel>
    {
        private readonly DataContext _context;

        public CreateUnitHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var unit = new Core.Entities.Unit(request.Code, request.Name, true);

                await _context.Units.AddAsync(unit, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Unidade cadastradada com sucesso!");
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error($"Erro ao cadastrar unidade: {ex.InnerException?.Message ?? ex.Message}");
            }
            
        }
    }
}

using GestaoColaboradores.Application.Models;
using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Queries.GetUnits
{
    public class GetUnitsHandler : IRequestHandler<GetUnitsQuery, ResultViewModel<List<UnitModel>>>
    {
        private readonly DataContext _context;

        public GetUnitsHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<UnitModel>>> Handle(GetUnitsQuery request, CancellationToken cancellationToken)
        {
            var units = await _context.Units
                 .AsNoTracking()
                 .Select(u => new UnitModel(u.Id, u.Code,u.Name, u.IsActive))
                 .ToListAsync(cancellationToken);

            return ResultViewModel<List<UnitModel>>.Success(units);
        }
    }
}

using GestaoColaboradores.Application.Models;
using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Queries.GetEmployees
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeesQuery, ResultViewModel<List<EmployeeModel>>>
    {
        private readonly DataContext _context;

        public GetEmployeeHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<EmployeeModel>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees
            .AsNoTracking()
            .Select(e => new EmployeeModel(
                e.Id,
                e.Code,
                e.Name,
                e.UnitId,
                e.Unit.Name,
                e.UserId,
                e.User.Login
            ))
            .ToListAsync(cancellationToken);

            return ResultViewModel<List<EmployeeModel>>.Success(employees);
        }
    }
}

using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Commands.CreateEmployee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResultViewModel>
    {
        private readonly DataContext _context;

        public CreateEmployeeHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == request.UnitId, cancellationToken);

                if (unit == null) return ResultViewModel.Error("Unidade não encontrada.");
                if (!unit.IsActive) return ResultViewModel.Error("Não é possível cadastrar colaborador em uma unidade inativa.");

                var userExists = await _context.Users.AnyAsync(u => u.Id == request.UserId, cancellationToken);
                if (!userExists) return ResultViewModel.Error("Usuário associado não encontrado.");

                var userAlreadyHasEmployee = await _context.Employees.AnyAsync(e => e.UserId == request.UserId, cancellationToken);
                if (userAlreadyHasEmployee) return ResultViewModel.Error("Este usuário já está vinculado a outro colaborador.");

                var employee = new Employee(request.Code, request.Name, request.UserId, request.UnitId);

                await _context.Employees.AddAsync(employee, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Colaborador cadastrado com sucesso!");
            }
            catch(Exception ex)
            {
                return ResultViewModel.Error($"Erro ao cadastrar colaborador: {ex.InnerException?.Message ?? ex.Message}");
            }
            
        }
    }
}

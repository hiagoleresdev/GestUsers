using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;

namespace GestaoColaboradores.Application.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultViewModel> 
    {
        private readonly DataContext _context;

        public CreateUserHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.Code, request.Login, request.PasswordHash, request.IsActive);

                await _context.Users.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultViewModel.Success("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error($"Erro ao cadastrar usuário: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}
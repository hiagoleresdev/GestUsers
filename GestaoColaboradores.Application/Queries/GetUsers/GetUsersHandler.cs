using GestaoColaboradores.Application.Models;
using GestaoColaboradores.Core.Entities;
using GestaoColaboradores.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Application.Queries.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, ResultViewModel<List<UserModel>>>
    {
        private readonly DataContext _context;

        public GetUsersHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<UserModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                 .AsNoTracking()
                 .Select(u => new UserModel(u.Id, u.Code, u.Login, u.PasswordHash, u.IsActive))
                 .ToListAsync(cancellationToken);

            return ResultViewModel<List<UserModel>>.Success(users);
        }
    }
}

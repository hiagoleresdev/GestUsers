using GestaoColaboradores.Application.Models;
using GestaoColaboradores.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<ResultViewModel<List<UserModel>>>
    {
    }
}

using GestaoColaboradores.Application.Models;
using GestaoColaboradores.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Queries.GetUnits
{
    public class GetUnitsQuery : IRequest<ResultViewModel<List<UnitModel>>>
    {
    }
}

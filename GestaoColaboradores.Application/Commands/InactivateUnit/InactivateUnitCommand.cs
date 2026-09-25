using GestaoColaboradores.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.InactivateUnit
{
    public class InactivateUnitCommand : IRequest<ResultViewModel>
    {
        public InactivateUnitCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

using GestaoColaboradores.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.DeleteUnit
{
    public class DeleteUnitCommand : IRequest<ResultViewModel>
    {
        public DeleteUnitCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

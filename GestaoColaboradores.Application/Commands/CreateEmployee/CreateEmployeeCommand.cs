using GestaoColaboradores.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<ResultViewModel>
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public int UserId { get; set; }
    }
}

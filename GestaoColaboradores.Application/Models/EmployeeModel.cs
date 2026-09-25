using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Models
{
    public class EmployeeModel
    {
        public EmployeeModel() { }

        public EmployeeModel(int id, string code, string name, int unitId, string unitName, int userId, string userLogin)
        {
            Id = id;
            Code = code;
            Name = name;
            UnitId = unitId;
            UnitName = unitName;
            UserId = userId;
            UserLogin = userLogin;
        }

        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;

        public int UserId { get; set; }
        public string UserLogin { get; set; } = string.Empty;
    }
}

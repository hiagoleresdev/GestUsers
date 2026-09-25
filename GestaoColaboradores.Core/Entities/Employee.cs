using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Core.Entities
{
    public class Employee : BaseEntity
    {
        public Employee(string code, string name, int userId, int unitId)
        {
            Code = code;
            Name = name;
            UserId = userId;
            UnitId = unitId;
        }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!;

        public void Update(string name, int unitId)
        {
            Name = name;
            UnitId = unitId;
        }
    }
}

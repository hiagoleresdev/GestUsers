using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Core.Entities
{
    public class Unit : BaseEntity
    {
        public Unit(string code, string name, bool isActive)
        {
            Code = code;
            Name = name;
            IsActive = isActive;
        }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public List<Employee> Employees { get; set; } = new();

        public void Update(string code, string name, bool isActive)
        {
            Code = code;
            Name = name;
            IsActive = isActive;
        }
        public void Inactivate()
        {
            IsActive = false;
        }
    }
}

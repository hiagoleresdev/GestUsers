using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Models
{
    public class UnitModel 
    {
        public UnitModel(int id, string code, string name, bool isActive)
        {
            Id = id;
            Code = code;
            Name = name;
            IsActive = isActive;
        }
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string code, string login, string passwordHash, bool isActive) : base()
        {
            Code = code;
            Login = login;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }

        public string Code { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public Employee? Employee { get; set; }
        public void Update(string code, string login, string passwordHash, bool isActive)
        {
            Code = code;
            Login = login;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }
    }
}

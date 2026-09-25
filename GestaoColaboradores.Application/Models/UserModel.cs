using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Application.Models
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(int id, string code, string login, string passwordHash, bool isActive)
        {
            Id = id;
            Code = code;
            Login = login;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }

        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}

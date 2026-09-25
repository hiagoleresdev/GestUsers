using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoColaboradores.Core.Entities
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        // Adicione esta sobrecarga aceitando a mensagem
        public static ResultViewModel Success(string message = "") => new ResultViewModel(true, message);

        public static ResultViewModel Error(string message) => new(false, message);
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }

        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T? data) => new ResultViewModel<T>(data);

        // Adicione esta sobrecarga para aceitar os dois argumentos (data e message)
        public static ResultViewModel<T> Success(T? data, string message) => new ResultViewModel<T>(data, true, message);

        public static ResultViewModel<T> Error(string message) => new(default, false, message);
    }
}

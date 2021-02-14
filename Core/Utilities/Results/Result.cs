using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        // constructor
        public Result(bool success, string message) : this(success) // tek parametreli olan constructor'a success'i yolla.
        {
            Message = message;
            // Success = success;   bu işlemi burada iptal edip alttaki constructor'a bıraktık.
        }

        // constructor
        // işlemin gerçekleşip gerçekleşmediğine dair mesaj yok. sadece başarı durumu var.
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        
        public string Message { get; }
    }
}

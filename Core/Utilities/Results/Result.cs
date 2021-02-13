using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool succsess, string message) : this(succsess)
        {
            Message = message;
        }
        public Result(bool succsess)
        {
            Success = succsess;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}

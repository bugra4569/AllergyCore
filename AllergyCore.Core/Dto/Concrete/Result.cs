using AllergyCore.Core.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Core.Dto.Concrete
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            IsSuccess = success;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}

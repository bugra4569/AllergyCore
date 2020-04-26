using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Core.Dto.Abstract
{
    public interface IResult:IDto
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}

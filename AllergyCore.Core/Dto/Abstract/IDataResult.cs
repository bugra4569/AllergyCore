﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Core.Dto.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}

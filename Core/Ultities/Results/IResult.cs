﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Core.Exceptions
{
    public class CustomBadRequestException : Exception
    {
        public CustomBadRequestException()
        {

        }

        public CustomBadRequestException(string message): base(message)
        {

        }
    }
}

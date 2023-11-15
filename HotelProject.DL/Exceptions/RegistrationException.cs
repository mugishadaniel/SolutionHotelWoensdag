﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DL.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RegistrationException(string message) : base(message)
        {
        }
    }

}

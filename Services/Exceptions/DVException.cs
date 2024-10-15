using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DVException : Exception
    {
        public DVErrorType ErrorType { get; }

        public DVException(DVErrorType errorType)
        {
            ErrorType = errorType;
        }
    }
}

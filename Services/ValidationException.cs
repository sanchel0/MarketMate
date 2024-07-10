using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ValidationException : Exception
    {
        public ValidationErrorType ErrorType { get; }

        public ValidationException(ValidationErrorType errorType)
        {
            ErrorType = errorType;
        }
    }
}

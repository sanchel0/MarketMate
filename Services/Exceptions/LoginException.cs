using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoginException : Exception
    {
        public LoginErrorType ErrorType { get; }

        public LoginException(LoginErrorType errorType)
        {
            ErrorType = errorType;
        }
    }
}

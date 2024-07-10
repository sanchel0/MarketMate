﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public enum LoginErrorType
    {
        SessionAlreadyStarted,
        InvalidUsername,
        InvalidPassword,
        MaxLoginAttemptsExceeded,
        UserBlocked,
        UserInactive
    }
}

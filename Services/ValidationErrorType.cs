using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public enum ValidationErrorType
    {
        IncompleteFields,
        OnlyLettersAllowed,
        OnlyNumbersAllowed,
        IncorrectLength8Digits,
        IncorrectLength10Digits,
        IncorrectLength16Digits,
        NoGridSelection,
        DuplicateName
    }
}

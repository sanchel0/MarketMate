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
        NoSelection,
        DuplicateName,
        DuplicateDni,
        DuplicateCUIT,
        NotFound,
        CurrentPasswordMismatch,
        PasswordChangeMismatch,
        PermissionAlreadyAssigned,
        UserAlreadyDeactivated,
        UserAlreadyActivated,
        UserNotBlocked,
        CannotRemoveBasicFamily,
        EmptyTreeView
    }
}

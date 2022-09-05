using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.library
{
    public class HelperMessage
    {
        
            public class Success
            {
                public const string Login = "Login Successfully";
                public const string Insert = "Insert Successfully";
                public const string Update = "Update Successfully";
            }
            public class Error
            {
                public const string LoginError = "Error Login";
                public const string LoginInvalid = "Invalid Login";
                public const string LoginEmpDeleted = "Employee Profile Deleted Please Contact IT!";
                public const string LoginEmpInactive = "Employee Profile Inactive Please Contact IT!";
                public const string Exception = "Error Exception:";
                public const string InsertError = "Insert Error";
            }
        }
}

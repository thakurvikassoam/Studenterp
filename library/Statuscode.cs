using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.library
{
    
        public enum StatusCode
        {
            Success = 200,
            Error = 100,
            Exception = 500
        }

        public enum ProcActionFlags
        {
            ADD = 1,
            UPDATE = 2,
            DELETE = 3,
            LIST = 4,
            BYID = 5,
            CANCEL = 6,
            REPLY = 7
        }
}

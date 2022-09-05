using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.library
{
    public class Webresponse
    {
        public bool IsSuccess { get; set; }
        public int statuscode { get; set; }
        public string Message { get; set; }
        public string successMessage { get; set; }
        public string ErrorMessage { get; set; }
        public object ResponseData { get; set; }
        public string Emailsendstatus { get; set; }
        public object ControllerName { get; set; }
        public object ActionName { get; set; }


    }
}

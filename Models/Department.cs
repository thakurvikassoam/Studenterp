using System;

namespace SVSU.Student.ERP.Models
{
    public class Department
    {

        public int Did { get; set; }
        public string Departmentname { get; set; }
        public string Departmentshortname { get; set; }
        public string Collegename { get; set; }
       
        public string mobile { get; set; }
        public string email { get; set; }
        public int statusid { get; set; }
             
        public DateTime modifytime { get; set; }
        public DateTime createtime { get; set; }
    }
}

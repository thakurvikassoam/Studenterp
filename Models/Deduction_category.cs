using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.Models
{
    public class Deduction_category
    {
        public int Id { get; set; }
        public string Deduction_Category { get; set; }
        public string Abbreviation { get; set; }
        public int Orderby { get; set; }
        public int  status { get; set; }
        public string Status { get; set; }
        
        public DateTime Createdate { get; set; }
        public DateTime Modifydate { get; set; }

    }
}

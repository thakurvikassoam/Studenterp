using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SVSU.Student.ERP.Models
{
    public class loginproperty
    {
        public int Id { get; set; }

        public List<SelectListItem> Items { get; set; }

        public string UserName { get; set; }

      
        public string Password { get; set; }

      
        public string Email { get; set; }

      
        public string Mobile { get; set; }
        public string MobileNo { get; set; }
        public int statusid { get; set; }
        public string Utype { get; set; }


        public DateTime createdate { get; set; }
        public DateTime modifydate { get; set; }

        public int id { get; set; }

        public string collegename { get; set; }
        public string Collegecode { get; set; }
        public string Collegeaddress { get; set; }
        public string Collegewebsite { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
     public DateTime modifytime { get; set; }
        public DateTime createtime { get; set; }
      
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SVSU.Student.ERP.Models
{
    public class Users:IdentityUser
    {
     
        
        public int Id { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> Externallogin { get; set; }
        public List<SelectListItem> Items { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public int Age { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Desigantion { get; set; }
        public string Department { get; set; }

        public string Email { get; set; }


        public string Mobile { get; set; }

        public DateTime createdate { get; set; }
        public DateTime modifydate { get; set; }
        public string status { get; set; }
    }
}

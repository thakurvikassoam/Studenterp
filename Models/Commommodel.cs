using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.Models
{
    public class Commommodel
    {
        /// <summary>
        /// for Session only
        /// </summary>
        public int Id { get; set; }
        public string session { get; set; }
        public string sessionfrom { get; set; }
        public string sessionto { get; set; }

        public string Orderby { get; set; }
        public string Status { get; set; }
        public int sessionstatusid { get; set; }
        public DateTime CreateDate { get; set; }       
        public List<SelectListItem> Items { get; set; }


    }
}

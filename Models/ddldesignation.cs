using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SVSU.Student.ERP.Models
{
    public class ddldesignation
    {
        public int Id { get; set; }
        public string Designationname { get; set; }
        public string DesignationShortname { get; set; }
        public string Orderby { get; set; }
        public int statusid { get; set; }
        public string Status { get; set; }
        public  DateTime creationdate { get; set; }
        public  DateTime modificationdate { get; set; }
        public List<SelectListItem> Items { get; set; }

    }
}

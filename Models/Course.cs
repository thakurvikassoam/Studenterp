using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.Models
{
    public class Course
    {

		public int CourseId { get; set; }
		public int CollegeId { get; set; }
		public string CourseName { get; set; }
		public int Statusid { get; set; }
		public int Orderby { get; set; }
		public string Status { get; set; }
		
		public DateTime CreateDate { get; set; }
		public DateTime ModifyDate { get; set; }
		public string Duration { get; set; }
		public string courseshortname { get; set; }
		public string coursecode { get; set; }
		
	}
}

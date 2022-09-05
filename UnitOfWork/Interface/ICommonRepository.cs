using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SVSU.Student.ERP.library;
using SVSU.Student.ERP.Models;

namespace SVSU.Student.ERP.UnitOfWork.Interface
{
    public interface ICommonRepository
    {

        public List<SelectListItem> GetddlCollege();
      //  public List<Course> GetAllCourseList();
      //  public Webresponse insertCourse(Course objcourse);
       // public Webresponse Insertdeduction_category(Deduction_category objdeduction);
      //  public Webresponse Insertdeduction(Deduction_Category_details objdeduction);
       // public List<Deduction_category> getdeduction_categorylist();
        public List<SelectListItem> GetddlDeduction();
//        public List<Deduction_Category_details> GetDeductionList();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SVSU.Student.ERP.library;
using SVSU.Student.ERP.Models;


namespace SVSU.Student.ERP.UnitOfWork.Interface
{
   public interface IUserRepository
    {
        public Webresponse SignIn(loginproperty objloginproperty);
        public Webresponse Signup(loginproperty objloginproperty);
       // public Webresponse Addcollege(loginproperty objloginproperty);
        //public List<CollegeDataList> GetAllCollegeList();
        //public List<DepartmentDatalist> GetAllDepartmentlist();
        //public Webresponse AddDepartment(Department objdepartment);
        //public Webresponse AddUsers(Users objuser);
        ////List<UserDataList> Signup(Users objuser);

        ////List<UserDataList> Signup(Users objuser);
        //public List<UserDataList> GetAllUserDataList();
        //public List<ddldesignation> GetAllDesignationList();
        //public Webresponse Setddldesignation(ddldesignation objddldesgnation);
        //public Webresponse Setddlsession(Commommodel objcommon);
        //public List<Commommodel> GetAllSessionList();
        //public CollegeDataList Getcollegeid(int id);
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SVSU.Student.ERP.library;
using SVSU.Student.ERP.Models;
using SVSU.Student.ERP.UnitOfWork.Interface;

namespace SVSU.Student.ERP.UnitOfWork.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapper _dapper;
        private loginproperty _objLPModel;
        private Department _objdepartment;
        private DynamicParameters parameter;
        internal Webresponse webResponce;
        private CollegeDataList collogemodel;
        public UserRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Webresponse SignIn(loginproperty objloginproperty)
        {
            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                this.parameter.Add(Parameter.USERNAME, objloginproperty.UserName, DbType.String);
                this.parameter.Add(Parameter.PASSWORD, objloginproperty.Password, DbType.String);
                var ObjRtnSp = _dapper.Get<loginproperty>(Procedurelist.USER_LOGIN, this.parameter, commandType: CommandType.StoredProcedure);
                loginproperty obj = new loginproperty();
                if (ObjRtnSp != null)
                {
                    obj.Id = ObjRtnSp.Id;
                    this.webResponce.successMessage = "";
                    this.webResponce.statuscode = (int)StatusCode.Success;
                    this.webResponce.ResponseData = obj.Id;


                }
                else
                {
                    this.webResponce.ErrorMessage = "User Not Found";
                    this.webResponce.statuscode = (int)StatusCode.Error;
                }
            }
            catch (Exception e)
            {
                this.webResponce.ErrorMessage = e.Message;
                this.webResponce.ResponseData = null;
                this.webResponce.statuscode = (int)StatusCode.Error;
            }
            return this.webResponce;
        }
        public Webresponse Signup(loginproperty objloginproperty)
        {
            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                this.parameter.Add(Parameter.EMAIL, objloginproperty.Email, DbType.String);
                this.parameter.Add(Parameter.USERNAME, objloginproperty.UserName, DbType.String);
                this.parameter.Add(Parameter.PASSWORD, objloginproperty.Password, DbType.String);
                var ObjRtnSp = _dapper.Insert<loginproperty>(Procedurelist.USER_INSERT, this.parameter, commandType: CommandType.StoredProcedure);
                if (ObjRtnSp != null)
                {
                    if (ObjRtnSp.Id > 0)
                    {
                        this._objLPModel.Id = ObjRtnSp.Id;
                        this.webResponce.successMessage = "User Account Created Successfully";
                        this.webResponce.ResponseData = this._objLPModel;
                        this.webResponce.statuscode = (int)StatusCode.Success;
                    }

                }
                else
                {
                    this.webResponce.ErrorMessage = "Something Went Wrong ! Try Again";
                    this.webResponce.ResponseData = null;
                    this.webResponce.statuscode = (int)StatusCode.Error;

                }
            }
            catch (Exception e)
            {
                this.webResponce.ErrorMessage = e.Message;
                this.webResponce.ResponseData = null;
                this.webResponce.statuscode = (int)StatusCode.Exception;

            }
            return this.webResponce;
        }

        public Webresponse Addcollege(loginproperty objloginproperty)
        {
            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                objloginproperty.createtime = DateTime.Now;
                objloginproperty.modifytime = DateTime.Now;
                this.parameter.Add(Parameter.collegename, objloginproperty.collegename, DbType.String);
                this.parameter.Add(Parameter.Collegecode, objloginproperty.Collegecode, DbType.String);
                this.parameter.Add(Parameter.Collegeaddress, objloginproperty.Collegeaddress, DbType.String);
                this.parameter.Add(Parameter.Collegewebsite, objloginproperty.Collegewebsite, DbType.String);
                this.parameter.Add(Parameter.EMAIL, objloginproperty.Email, DbType.String);
                this.parameter.Add(Parameter.statusid, objloginproperty.statusid, DbType.Int32);
                this.parameter.Add(Parameter.MobileNo, objloginproperty.MobileNo, DbType.String);
                this.parameter.Add(Parameter.createtime, objloginproperty.createtime, DbType.DateTime);
                this.parameter.Add(Parameter.modifytime, objloginproperty.modifytime, DbType.DateTime);
                var ObjRtnSp = _dapper.Get<loginproperty>(Procedurelist.Addcollege, this.parameter, commandType: CommandType.StoredProcedure);

                if (ObjRtnSp.id > 0)
                {
                    this._objLPModel.Id = ObjRtnSp.Id;
                    this.webResponce.successMessage = "College Create SuccesFully";
                    this.webResponce.statuscode = (int)StatusCode.Success;
                    this.webResponce.ResponseData = this._objLPModel;


                }
                else
                {
                    this.webResponce.ErrorMessage = "Something Went Wrong ! Try Again";
                    this.webResponce.ResponseData = null;
                    this.webResponce.statuscode = (int)StatusCode.Error;

                }
            }
            catch (Exception e)
            {
                this.webResponce.ErrorMessage = e.Message;
                this.webResponce.ResponseData = null;
                this.webResponce.statuscode = (int)StatusCode.Exception;
            }
            return this.webResponce;
        }

        public CollegeDataList Getcollegeid(int id)
        {
            this.parameter = new DynamicParameters() ;
            this.collogemodel = new CollegeDataList();
            this.parameter.Add(Parameter.Id, id, DbType.Int32);
            var objcoll = _dapper.Get<CollegeDataList>(Procedurelist.getcollegelistbyid, parameter, commandType: CommandType.StoredProcedure);
            if (objcoll != null)
            {
                this.collogemodel.Id = objcoll.Id;
                this.collogemodel.collegename = objcoll.collegename;
                this.collogemodel.Collegeaddress = objcoll.Collegeaddress;
                this.collogemodel.Collegecode = objcoll.Collegecode;
                this.collogemodel.Collegewebsite = objcoll.Collegewebsite;
                this.collogemodel.email = objcoll.email;
                this.collogemodel.mobile = objcoll.mobile;
                this.collogemodel.status = objcoll.status;
            }

            return collogemodel;
        }




        public List<CollegeDataList> GetAllCollegeList()
        
        {
           
            var objsp = _dapper.GetAll<CollegeDataList>(Procedurelist.Collegelist, null, commandType: CommandType.StoredProcedure);
              var result = objsp.Select(x => new CollegeDataList()
              {
                  Id = x.Id,
                  collegename=x.collegename,
                  Collegeaddress=x.Collegeaddress,                  
                  Collegewebsite=x.Collegewebsite,
                  Collegecode=x.Collegecode,
                  mobile=x.mobile,
                  email=x.email, 
                  status=x.status

              }).ToList();
            return result.ToList();




        }

        public Webresponse AddDepartment(Department objdepartment)
        {
            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                objdepartment.createtime = DateTime.Now;
                objdepartment.modifytime = DateTime.Now;
                this.parameter.Add(Parameter.Departmentname, objdepartment.Departmentname, DbType.String);
                this.parameter.Add(Parameter.Departmentshortname, objdepartment.Departmentshortname, DbType.String);
                this.parameter.Add(Parameter.Collegename, objdepartment.Collegename, DbType.String);
                this.parameter.Add(Parameter.email, objdepartment.email, DbType.String);
                
                this.parameter.Add(Parameter.statusid, objdepartment.statusid, DbType.Int32);
                this.parameter.Add(Parameter.MobileNo, objdepartment.mobile, DbType.String);
                this.parameter.Add(Parameter.createtime, objdepartment.createtime, DbType.DateTime);
                this.parameter.Add(Parameter.modifytime, objdepartment.modifytime, DbType.DateTime);
                var ObjRtnSp = _dapper.Get<loginproperty>(Procedurelist.AddDepartment, this.parameter, commandType: CommandType.StoredProcedure);

                if (ObjRtnSp.id > 0)
                {
                    this._objdepartment.Did = ObjRtnSp.Id;
                    this.webResponce.successMessage = "Department Create SuccesFully";
                    this.webResponce.statuscode = (int)StatusCode.Success;
                    this.webResponce.ResponseData = this._objLPModel;


                }
                else
                {
                    this.webResponce.ErrorMessage = "Something Went Wrong ! Try Again";
                    this.webResponce.ResponseData = null;
                    this.webResponce.statuscode = (int)StatusCode.Error;

                }
            }
            catch (Exception e)
            {
                this.webResponce.ErrorMessage = e.Message;
                this.webResponce.ResponseData = null;
                this.webResponce.statuscode = (int)StatusCode.Exception;
            }
            return this.webResponce;
        }


        public List<DepartmentDatalist> GetAllDepartmentlist()

        {

            var objsp = _dapper.GetAll<DepartmentDatalist>(Procedurelist.DepartmentList, null, commandType: CommandType.StoredProcedure);
            var result = objsp.Select(x => new DepartmentDatalist()
            {
                Did=x.Did,
                Departmentname=x.Departmentname,
                Departmentshortname=x.Departmentshortname,
                Collegename=x.Collegename,
                mobile=x.mobile,
                email=x.email,
                status=x.status
                //Did = x.Did,
                //Departmentname = x.Departmentname,
                //Departmentshortname = x.Departmentshortname,
                //Collegename = x.Collegename,
                //mobile = x.mobile,
                //email = x.email,
                //statusid = x.statusid

            }).ToList();
            return result.ToList();




        }


        public List<UserDataList> GetAllUserDataList()
        {

            var objsp = _dapper.GetAll<UserDataList>(Procedurelist.Userslist, null, commandType: CommandType.StoredProcedure);
            var result = objsp.Select(x => new UserDataList()
            {
                Id=x.Id,
                Username = x.Username,
               Lastname=x.Lastname,
               //Mothername=x.Mothername,
               Fathername=x.Fathername,
               Department=x.Department,
               Desigantion=x.Desigantion,
               mobileno=x.mobileno,
               Password=x.Password,
               createdate=x.createdate,
               Email=x.Email,
                status = x.status
            }).ToList();
            return result.ToList();




        }






        public Webresponse AddUsers(Users objuser)
        {
            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
               
                objuser.createdate = DateTime.Now;
                objuser.modifydate = DateTime.Now;
                this.parameter.Add(Parameter.Firstname, objuser.Firstname, DbType.String);
                this.parameter.Add(Parameter.Lastname, objuser.Lastname, DbType.String);
                this.parameter.Add(Parameter.Fathername, objuser.Fathername, DbType.String);
                this.parameter.Add(Parameter.Mothername, objuser.Mothername, DbType.String);

                this.parameter.Add(Parameter.Age, objuser.Age, DbType.Int32);
                this.parameter.Add(Parameter.Desigantion, objuser.Desigantion, DbType.String);
                this.parameter.Add(Parameter.Department, objuser.Department, DbType.String);
                this.parameter.Add(Parameter.PAddress, objuser.Address, DbType.String);
                this.parameter.Add(Parameter.City, objuser.City, DbType.String);
                this.parameter.Add(Parameter.State, objuser.State, DbType.String);
                this.parameter.Add(Parameter.Country, objuser.Country, DbType.String);
                this.parameter.Add(Parameter.createdate, objuser.createdate, DbType.String);
                this.parameter.Add(Parameter.modifydate, objuser.modifydate, DbType.String);
                var ObjRtnSp = _dapper.Insert<Users>(Procedurelist.AddUser_detail, this.parameter, commandType: CommandType.StoredProcedure);
                if (ObjRtnSp != null)
                {
                    if (ObjRtnSp.Id > 0)
                    {
                        //this._objdepartment.Did = ObjRtnSp.Id;
                        this.webResponce.successMessage = "Create SuccesFully";
                        this.webResponce.statuscode = (int)StatusCode.Success;
                        this.webResponce.ResponseData = this._objLPModel;


                    }
                }
                else
                {
                    this.webResponce.ErrorMessage = "Something Went Wrong ! Try Again";
                    this.webResponce.ResponseData = null;
                    this.webResponce.statuscode = (int)StatusCode.Error;

                }
            }
            catch (Exception e)
            {
                this.webResponce.ErrorMessage = e.Message;
                this.webResponce.ResponseData = null;
                this.webResponce.statuscode = (int)StatusCode.Exception;
            }
            return this.webResponce;
        }


        public Webresponse Setddldesignation(ddldesignation objddldesgnation)
        {
           
            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                objddldesgnation.creationdate = DateTime.Now;
                objddldesgnation.modificationdate = DateTime.Now;
                int s = 1;
                objddldesgnation.statusid = s;
                this.parameter.Add(Parameter.Designationname, objddldesgnation.Designationname, DbType.String);
                this.parameter.Add(Parameter.DesignationShortname, objddldesgnation.DesignationShortname, DbType.String);
                this.parameter.Add(Parameter.Orderby, objddldesgnation.Orderby, DbType.Int32);
                this.parameter.Add(Parameter.createdate, objddldesgnation.creationdate, DbType.String);
                this.parameter.Add(Parameter.modifydate, objddldesgnation.modificationdate, DbType.String);
                this.parameter.Add(Parameter.statusid, objddldesgnation.statusid, DbType.Int32);
                var ObjRtnSp = _dapper.Insert<ddldesignation>(Procedurelist.Insert_Designation, this.parameter, commandType: CommandType.StoredProcedure);
                if (ObjRtnSp != null)
                {
                    if (ObjRtnSp.Id > 0)
                    {
                        this._objLPModel.Id = ObjRtnSp.Id;
                        this.webResponce.successMessage = "Created Successfully";
                        this.webResponce.ResponseData = this._objLPModel;
                        this.webResponce.statuscode = (int)StatusCode.Success;
                    }

                }
                else
                {
                    this.webResponce.ErrorMessage = "Something Went Wrong ! Try Again";
                    this.webResponce.ResponseData = null;
                    this.webResponce.statuscode = (int)StatusCode.Error;

                }
            }
            catch (Exception e)
            {
                this.webResponce.ErrorMessage = e.Message;
                this.webResponce.ResponseData = null;
                this.webResponce.statuscode = (int)StatusCode.Exception;

            }
            return this.webResponce;
        }




        public List<ddldesignation> GetAllDesignationList()
        {

            var objsp = _dapper.GetAll<ddldesignation>(Procedurelist.Designationlist, null, commandType: CommandType.StoredProcedure);
            var result = objsp.Select(x => new ddldesignation()
            {
                
              Designationname=x.Designationname,
              DesignationShortname=x.DesignationShortname,
                Orderby=x.Orderby,
                Status = x.Status


            }).ToList();
            return result.ToList();




        }




        public Webresponse Setddlsession(Commommodel objcommon)
        {

            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                objcommon.CreateDate = DateTime.Now;
               
                int s = 1;
                objcommon.sessionstatusid = s;
                this.parameter.Add(Parameter.session, objcommon.session, DbType.String);
                this.parameter.Add(Parameter.sessionfrom, objcommon.sessionfrom, DbType.String);
                this.parameter.Add(Parameter.sessionto, objcommon.sessionto, DbType.Int32);
                this.parameter.Add(Parameter.orderby, objcommon.Orderby, DbType.String);
                this.parameter.Add(Parameter.sessionstatusid, objcommon.sessionstatusid, DbType.String);
                this.parameter.Add(Parameter.CreateDate, objcommon.CreateDate, DbType.DateTime);
                var ObjRtnSp = _dapper.Insert<Commommodel>(Procedurelist.insert_session, this.parameter, commandType: CommandType.StoredProcedure);
                if (ObjRtnSp != null)
                {
                    if (ObjRtnSp.Id > 0)
                    {
                        this._objLPModel.Id = ObjRtnSp.Id;
                        this.webResponce.successMessage = "Created Successfully";
                        this.webResponce.ResponseData = this._objLPModel;
                        this.webResponce.statuscode = (int)StatusCode.Success;
                    }

                }
                else
                {
                    this.webResponce.ErrorMessage = "Something Went Wrong ! Try Again";
                    this.webResponce.ResponseData = null;
                    this.webResponce.statuscode = (int)StatusCode.Error;

                }
            }
            catch (Exception e)
            {
                this.webResponce.ErrorMessage = e.Message;
                this.webResponce.ResponseData = null;
                this.webResponce.statuscode = (int)StatusCode.Exception;

            }
            return this.webResponce;
        }



        public List<Commommodel> GetAllSessionList()
        {

            var objsp = _dapper.GetAll<Commommodel>(Procedurelist.Sessionlist, null, commandType: CommandType.StoredProcedure);
            var result = objsp.Select(x => new Commommodel()
            {

                session = x.session,
                sessionfrom=x.sessionfrom,
                sessionto=x.sessionto,
                //sessionstatusid=x.sessionstatusid,
                Orderby = x.Orderby,
                Status = x.Status


            }).ToList();
            return result.ToList();




        }

     



    }
}

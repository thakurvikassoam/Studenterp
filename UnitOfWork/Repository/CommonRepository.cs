using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SVSU.Student.ERP.library;
using SVSU.Student.ERP.Models;
using SVSU.Student.ERP.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SVSU.Student.ERP.UnitOfWork.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IDapper _dapper;
        private loginproperty _objLPModel;
       
        private DynamicParameters parameter;
        internal Webresponse webResponce;



        SelectListItem SelectList = new SelectListItem() { Value = "0", Text = "Select" };
        public CommonRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public List<SelectListItem> GetddlCollege()
        {
            var objcollege = _dapper.GetAll<CollegeDataList>(Procedurelist.getddlcollege, null, commandType: CommandType.StoredProcedure);
            var objlist = objcollege.Select(x => new SelectListItem()

            {
                Value = x.Id.ToString(),
                Text = x.collegename,
            }).ToList();
            objlist.Insert(0, SelectList);
            return objlist.ToList();

        }

        public List<SelectListItem> GetddlDeduction()
        {
            var objcollege = _dapper.GetAll<Deduction_category>(Procedurelist.ddlDeduction, null, commandType: CommandType.StoredProcedure);
            var objlist = objcollege.Select(x => new SelectListItem()

            {
                Value = x.Id.ToString(),
                Text = x.Deduction_Category,
            }).ToList();
            objlist.Insert(0, SelectList);
            return objlist.ToList();

        }
        public List<Course> GetAllCourseList()
        {
            var objcollege = _dapper.GetAll<Course>(Procedurelist.Courselist, null, commandType: CommandType.StoredProcedure);
            var objlist = objcollege.Select(x => new Course()
            {
                coursecode = x.coursecode,
                CourseName = x.CourseName,
                courseshortname = x.courseshortname,
                Orderby = x.Orderby,
                Status = x.Status
            }).ToList();


            return objlist.ToList();

        }
        public List<Course> Getddlcourse()
        {

            var objsp = _dapper.GetAll<Course>(Procedurelist.Designationlist, null, commandType: CommandType.StoredProcedure);
            var result = objsp.Select(x => new Course()
            {

                coursecode = x.coursecode,
                CourseName = x.CourseName,
                courseshortname = x.courseshortname,
                Orderby = x.Orderby,
                Status = x.Status


            }).ToList();
            return result.ToList();

        }
        public Webresponse insertCourse(Course objcourse)

        {

            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                objcourse.CreateDate = DateTime.Now;
                objcourse.ModifyDate = DateTime.Now;
                int s = 1;
                objcourse.Statusid = s;

                this.parameter.Add(Parameter.CollegeId, objcourse.CollegeId, DbType.String);
                this.parameter.Add(Parameter.coursecode, objcourse.coursecode, DbType.String);
                this.parameter.Add(Parameter.CourseName, objcourse.CourseName, DbType.String);
                this.parameter.Add(Parameter.courseshortname, objcourse.courseshortname, DbType.String);
                this.parameter.Add(Parameter.Duration, objcourse.Duration, DbType.String);
                this.parameter.Add(Parameter.CreateDates, objcourse.CreateDate, DbType.String);
                this.parameter.Add(Parameter.ModifyDate, objcourse.ModifyDate, DbType.String);
                this.parameter.Add(Parameter.Orderno, objcourse.Orderby, DbType.Int32);
                this.parameter.Add(Parameter.Statusid, objcourse.Statusid, DbType.Int32);
                var ObjRtnSp = _dapper.Insert<Course>(Procedurelist.InsertCourse, this.parameter, commandType: CommandType.StoredProcedure);
                if (ObjRtnSp != null)
                {
                    if (ObjRtnSp.CourseId > 0)
                    {
                        this._objLPModel.Id = ObjRtnSp.CourseId;
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

        public Webresponse Insertdeduction_category(Deduction_category objdeduction)

        {

            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                objdeduction.Createdate = DateTime.Now;
                objdeduction.Modifydate = DateTime.Now;
                int s = 1;
                objdeduction.status = s;


                this.parameter.Add(Parameter.Deduction_Category, objdeduction.Deduction_Category, DbType.String);
                this.parameter.Add(Parameter.Abbreviation, objdeduction.Abbreviation, DbType.String);

                this.parameter.Add(Parameter.CreateDatess, objdeduction.Createdate, DbType.String);
                this.parameter.Add(Parameter.ModifyDates, objdeduction.Modifydate, DbType.String);
                this.parameter.Add(Parameter.Order, objdeduction.Orderby, DbType.Int32);
                this.parameter.Add(Parameter.statuss, objdeduction.status, DbType.Int32);
                var ObjRtnSp = _dapper.Insert<Deduction_category>(Procedurelist.InsertDediction_category, this.parameter, commandType: CommandType.StoredProcedure);
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
        public Webresponse Insertdeduction(Deduction_Category_details objdeduction)
        {

            this.parameter = new DynamicParameters();
            this.webResponce = new Webresponse();
            this._objLPModel = new loginproperty();
            try
            {
                objdeduction.Createdate = DateTime.Now;
                objdeduction.Modifydate = DateTime.Now;
                int s = 1;
                objdeduction.status = s;


                this.parameter.Add(Parameter.Deduction_Category, objdeduction.Deduction_Category, DbType.String);
                this.parameter.Add(Parameter.Abbreviation, objdeduction.Abbreviation, DbType.String);
                this.parameter.Add(Parameter.Deduction, objdeduction.Deduction, DbType.String);
                this.parameter.Add(Parameter.CreateDatess, objdeduction.Createdate, DbType.String);
                this.parameter.Add(Parameter.ModifyDates, objdeduction.Modifydate, DbType.String);
                this.parameter.Add(Parameter.Order, objdeduction.OrderBy, DbType.Int32);
                this.parameter.Add(Parameter.statuss, objdeduction.status, DbType.Int32);
                var ObjRtnSp = _dapper.Insert<Deduction_category>(Procedurelist.Insert_dedcution, this.parameter, commandType: CommandType.StoredProcedure);
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

        public List<Deduction_category> getdeduction_categorylist()
        {

            var objsp = _dapper.GetAll<Deduction_category>(Procedurelist.Deductions_CategoryList, null, commandType: CommandType.StoredProcedure);
            var objlist = objsp.Select(x => new Deduction_category()
            {

                Deduction_Category = x.Deduction_Category,
                Abbreviation = x.Abbreviation,

                Orderby = x.Orderby,
                Status = x.Status


            }).ToList();
            return objlist.ToList();

        }

        public List<Deduction_Category_details> GetDeductionList()
        {
            var objsp = _dapper.GetAll<Deduction_Category_details>(Procedurelist.Deductionlist, null, commandType: CommandType.StoredProcedure);
            var objlist = objsp.Select(x => new Deduction_Category_details()
            {
                Deduction = x.Deduction,
                Deduction_Category = x.Deduction_Category,
                Abbreviation = x.Abbreviation,
                OrderBy = x.OrderBy,
                Status = x.Status
            }).ToList();
            return objlist.ToList();
        }



    }
}

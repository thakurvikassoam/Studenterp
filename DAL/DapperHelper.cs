using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.Models
{
    public class DapperHelper : IDapper
    {
        private readonly IConfiguration _configuration;
        public DapperHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbConnection connection()
        {
            return new SqlConnection(_configuration.GetConnectionString("constring"));
        }

        public int Execute(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("dbConnection")))
            {
                
                return db.Execute(sp, parameters, commandType: commandType);
            }
        }

        public T Get<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("dbConnection")))
            {

                return db.Query<T>(sp, parameters, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("dbConnection")))
            {
                return db.Query<T>(sp, parameters, commandType: commandType).ToList();
            }
        }

        public T Insert<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("dbConnection")))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parameters, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
                return result;
            }
        }

        public T Update<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("dbConnection")))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parameters, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
                return result;
            }
        }
    }
}

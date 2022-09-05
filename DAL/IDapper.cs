using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.Models
{
    public interface IDapper
    {
        DbConnection connection();
        T Get<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}

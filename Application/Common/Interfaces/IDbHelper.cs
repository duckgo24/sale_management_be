using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace WebApi.DBHelper
{
    public interface IDbHelper
    {
        Task<T> ExcuteProceduceSingleDataAsync<T>(string procedureName, DynamicParameters parameters);
        Task<List<T>> ExcuteProceduceMultiDataAsync<T>(string procedureName, DynamicParameters parameters);
        Task<T> ExcuteProceduceByUserAsync<T>(string procedureName, DynamicParameters parameters);
    }
}
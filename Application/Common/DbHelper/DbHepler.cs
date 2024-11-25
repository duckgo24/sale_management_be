using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Application.Interface;

namespace WebApi.DBHelper
{
    public class DbHepler : IDbHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IUser _user;
        private SqlTransaction? sqlTransaction;
        public DbHepler(IConfiguration configuration, IUser user)
        {
            _configuration = configuration;
            _user = user;
        }

        public async Task<T> ExcuteProceduceAsync<T>(string procedureName, DynamicParameters parameters)
        {
            var conn = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    var result = await connection.QueryFirstOrDefaultAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
                    if (result == null)
                    {
                        return default!;
                    }
                    return result;
                }
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException("Query returned null.");
            }
        }

        public async Task<T> ExcuteProceduceByUserAsync<T>(string procedureName, DynamicParameters parameters)
        {
            var conn = _configuration.GetConnectionString("DefaultConnection");
            parameters.Add("created_at", DateTime.Now);
            parameters.Add("last_updated", DateTime.Now);
            parameters.Add("created_by", _user.getCurrentUser());
            parameters.Add("updated_by", _user.getCurrentUser());
            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    var result = await connection.QueryFirstOrDefaultAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
                    if (result == null)
                    {
                        return default!;
                    }
                    return result;
                }
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException("Query returned null.");
            }
        }
    }
}
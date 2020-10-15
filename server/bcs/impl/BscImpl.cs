
using Dapper;
using MediaService.model;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using WebApi.data;

namespace DashBoardService.server.bcs.impl
{
    public class BscImpl : IBsc
    {
        private IConfiguration m_configuration;
  
        public BscImpl(IConfiguration configuration)
        {
            m_configuration = configuration;
        }
 
    
        public dynamic getMedia(Request request)
        {
            dynamic result = null;
            var dyParam = new OracleDynamicParameters();
            dyParam.Add("sodt", OracleDbType.Varchar2, ParameterDirection.Input, request.sodt);

            dyParam.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "THUEBAO_DONVI.layThueBao";
                result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = m_configuration.GetSection("connectionstrings").GetSection("defaultconnection2").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}

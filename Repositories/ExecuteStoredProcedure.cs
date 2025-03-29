using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using Library.Utility.Attributes;
using Newtonsoft.Json;
using Library.Exceptions.CustomExceptions;

namespace Library.Repository
    {
        public class ExecuteStoredProcedure : IExecuteStoredProcedure
        {
            public readonly string ConnectionString;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public ExecuteStoredProcedure(IConfiguration configuration, IHttpContextAccessor httpContextAccessor){
                ConnectionString = configuration.GetConnectionString("DefaultConnection");
                _httpContextAccessor = httpContextAccessor;
            }

        public async Task<bool> CallNonQueryStoredProcedure<T>(string StoredProcedure, T Parameters, bool is_with_userId)
        {
            Boolean IsSuccess = true;
            try{
                using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    await sqlConnection.OpenAsync();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = StoredProcedure;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 0;
                    sqlCommand.Connection = sqlConnection;

                    if(Parameters != null){
                        var props = TypeDescriptor.GetProperties(Parameters);
                        foreach (PropertyDescriptor prop in props)
                        {
                            if(!Equals(prop.GetValue(Parameters), null)){
                                string paramName = "@" + prop.Name;
                                object paramValue;
                                if(!Equals(prop.Attributes[typeof(TableTypeAttribute)], null)){
                                    var ListValue = prop.GetValue(Parameters);
                                    if(ListValue.GetType().IsSerializable){
                                        string JsonData = JsonConvert.SerializeObject(ListValue);
                                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(JsonData);
                                        if(dt != null && dt.Columns.Count > 0 && dt.Rows.Count > 0){
                                            sqlCommand.Parameters.Add(new SqlParameter(paramName, dt));
                                        }
                                    }
                                }
                                else{
                                    paramValue = prop.GetValue(Parameters) ?? DBNull.Value;
                                    sqlCommand.Parameters.AddWithValue(paramName, paramValue);
                                }
                            }
                        }
                    }

                    if(is_with_userId){
                        int userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.Items["UserId"]);
                        sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    }

                    var response = await sqlCommand.ExecuteNonQueryAsync();
                    if (response == -1)
                    {
                        IsSuccess = false;
                    }
                }
            }
            catch(SqlException ex){
                throw new Exception(ex.Message.ToString());
            }
            return IsSuccess;
        }

        public async Task<DataSet> CallStoredProcedure<T> (string StoredProcedure, T Parameters, bool is_with_userId){

                DataSet ds = new DataSet();

                using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = StoredProcedure;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 0;
                    sqlCommand.Connection = sqlConnection;

                    if(Parameters != null){
                        var props = TypeDescriptor.GetProperties(Parameters);
                        foreach (PropertyDescriptor prop in props)
                        {
                            if(!Equals(prop.GetValue(Parameters), null)){
                                string paramName = "@" + prop.Name;
                                object paramValue;
                                if(!Equals(prop.Attributes[typeof(TableTypeAttribute)], null)){
                                    var ListValue = prop.GetValue(Parameters);
                                    if(ListValue.GetType().IsSerializable){
                                        string JsonData = JsonConvert.SerializeObject(ListValue);
                                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(JsonData);
                                        if(dt != null && dt.Columns.Count > 0 && dt.Rows.Count > 0){
                                            sqlCommand.Parameters.Add(new SqlParameter(paramName, dt));
                                        }
                                    }
                                }
                                else{
                                    paramValue = prop.GetValue(Parameters) ?? DBNull.Value;
                                    sqlCommand.Parameters.AddWithValue(paramName, paramValue);
                                }
                            }
                        }
                    }

                    if(is_with_userId){
                        int userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.Items["UserId"]);
                        sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    }

                    sqlConnection.Open();
                    using(SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand)){
                        adapter.Fill(ds);
                    }
                }
            return ds;
        }
    }
}

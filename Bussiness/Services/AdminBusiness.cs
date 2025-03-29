using System.Data;
using Library.Business.Interface;
using Library.Exceptions.CustomExceptions;
using Library.Middleware;
using Library.Models.Request;
using Library.Repository;
using Library.Utility.DBConstants;

namespace Library.Business.Services
{
    public class AdminBusiness : IAdminBusiness
    {

        private readonly IExecuteStoredProcedure _executeStoredProcedure;

        public AdminBusiness(IExecuteStoredProcedure executeStoredProcedure){
            _executeStoredProcedure = executeStoredProcedure;
        }

        public async Task<DataSet> GetALlUsers()
        {
            DataSet ds = new DataSet();

            ds = await _executeStoredProcedure.CallStoredProcedure<object>(StoredProcedureConstants.GET_ALL_USERS, null, true);

            return ds;
        }
    }
}
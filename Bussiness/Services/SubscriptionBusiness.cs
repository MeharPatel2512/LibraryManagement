using System.Data;
using Library.Business.Interface;
using Library.Exceptions.CustomExceptions;
using Library.Middleware;
using Library.Models.Request;
using Library.Repository;
using Library.Utility.DBConstants;

namespace Library.Business.Services
{
    public class SubscriptionBusiness : ISubscriptionBusiness
    {
        private readonly IExecuteStoredProcedure _executeStoredProcedure;

        public SubscriptionBusiness(IExecuteStoredProcedure executeStoredProcedure){
            _executeStoredProcedure = executeStoredProcedure;
        }
        public async Task<DataSet> GetSubscriptionTypes()
        {
            DataSet ds = new DataSet();

            ds = await _executeStoredProcedure.CallStoredProcedure<object>(StoredProcedureConstants.GET_SUBSCRIPTION_TYPES, null, false);

            return ds;
        }
    }
}
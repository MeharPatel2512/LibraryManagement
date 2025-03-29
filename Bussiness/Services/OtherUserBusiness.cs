using System.Data;
using Library.Business.Interface;
using Library.Middleware;
using Library.Models.Request;
using Library.Repository;
using Library.Utility.DBConstants;

namespace Library.Business.Services
{
    public class OtherUserBusiness : IOtherUserBusiness
    {

        private readonly IExecuteStoredProcedure _executeStoredProcedure;

        public OtherUserBusiness(IExecuteStoredProcedure executeStoredProcedure){
            _executeStoredProcedure = executeStoredProcedure;
        }

        public async Task<DataSet> GetProfileData(OtherUserModel.GetProfileModel getProfileModel)
        {
            DataSet ds = new DataSet();

            ds = await _executeStoredProcedure.CallStoredProcedure<OtherUserModel.GetProfileModel>(StoredProcedureConstants.GET_PROFILE, getProfileModel, false);

            return ds;
        }
    }
}
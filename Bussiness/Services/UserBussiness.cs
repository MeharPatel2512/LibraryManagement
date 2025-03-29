using System.Data;
using Library.Business.Interface;
using Library.Exceptions.CustomExceptions;
using Library.Middleware;
using Library.Models.Request;
using Library.Repository;
using Library.Utility.DBConstants;

namespace Library.Business.Services
{
    public class UserBusiness : IUserBusiness
    {

        private readonly IExecuteStoredProcedure _executeStoredProcedure;

        public UserBusiness(IExecuteStoredProcedure executeStoredProcedure){
            _executeStoredProcedure = executeStoredProcedure;
        }

        public async Task<DataSet> GetMyProfileData()
        {
            DataSet ds = new DataSet();

            ds = await _executeStoredProcedure.CallStoredProcedure<object>(StoredProcedureConstants.GET_PROFILE, null, true);

            return ds;
        }

        public async Task UpdateMyData(UserModel.UpdateUserDataModel updateUserDataModel)
        {
            await _executeStoredProcedure.CallNonQueryStoredProcedure<UserModel.UpdateUserDataModel>(StoredProcedureConstants.UPDATE_USER_DATA, updateUserDataModel, true);
        }

        public async Task DeleteUser(UserModel.DeleteMyAccountModel deleteMyAccountModel)
        {
            DataSet ds = new DataSet();

            ds = await _executeStoredProcedure.CallStoredProcedure<object>(StoredProcedureConstants.GET_HASHPASSWORD, null, true);

            bool is_correct = PasswordHasher.VerifyPassword(deleteMyAccountModel.Password, ds.Tables[0].Rows[0]["PasswordHash"].ToString() ?? "");

            if(is_correct){
                await _executeStoredProcedure.CallNonQueryStoredProcedure<object>(StoredProcedureConstants.DELETE_USER, null, true);
            }
            else throw new UnauthorizedException();
        }

        public async Task ChangePassword(UserModel.ChangePasswordUIModel changePasswordUIModel)
        {
            DataSet ds = new DataSet();

            ds = await _executeStoredProcedure.CallStoredProcedure<object>(StoredProcedureConstants.GET_HASHPASSWORD, null, true);

            bool is_correct = PasswordHasher.VerifyPassword(changePasswordUIModel.OldPassword, ds.Tables[0].Rows[0]["PasswordHash"].ToString() ?? "");

            if(is_correct && changePasswordUIModel.NewPassword == changePasswordUIModel.ConfirmNewPassword){
                UserModel.ChangePasswordDBModel changePasswordDBModel = new UserModel.ChangePasswordDBModel{
                    NewPassword = PasswordHasher.HashPassword(changePasswordUIModel.NewPassword)
                };
                await _executeStoredProcedure.CallNonQueryStoredProcedure<UserModel.ChangePasswordDBModel>(StoredProcedureConstants.CHANGE_PASSWORD, changePasswordDBModel, true);
            }
            else throw new UnauthorizedException("Not Authorized");
        }

        public async Task GetSubscription(UserModel.GetSubscriptionModel getSubscriptionModel)
        {
            await _executeStoredProcedure.CallNonQueryStoredProcedure<UserModel.GetSubscriptionModel>(StoredProcedureConstants.GET_SUBSCRIPTION, getSubscriptionModel, true);
        }
        public async Task<DataSet> GetBorrowedBooks()
        {
            DataSet ds = new DataSet();

            ds = await _executeStoredProcedure.CallStoredProcedure<object>(StoredProcedureConstants.GET_BORROWED_BOOKS, null, true);

            return ds;
        }
    }
}
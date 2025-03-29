using System.Data;
using Library.Models.Request;

namespace Library.Business.Interface
{
    public interface IUserBusiness{
        Task<DataSet> GetMyProfileData();
        Task UpdateMyData(UserModel.UpdateUserDataModel updateUserDataModel);
        Task DeleteUser(UserModel.DeleteMyAccountModel deleteMyAccountModel);
        Task ChangePassword(UserModel.ChangePasswordUIModel changePasswordUIModel);
        Task GetSubscription(UserModel.GetSubscriptionModel getSubscriptionModel);
        Task<DataSet> GetBorrowedBooks();
    }
}
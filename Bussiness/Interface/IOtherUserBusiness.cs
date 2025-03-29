using System.Data;
using Library.Models.Request;

namespace Library.Business.Interface
{
    public interface IOtherUserBusiness{
        Task<DataSet> GetProfileData(OtherUserModel.GetProfileModel getProfileModel);
        // Task UpsertUser(UserModel.UpsertUserUIModel upsertUserUIModel);
        // Task DeleteUser(UserModel.DeleteUserModel deleteUserModel);
        // Task GetSubscription();
    }
}
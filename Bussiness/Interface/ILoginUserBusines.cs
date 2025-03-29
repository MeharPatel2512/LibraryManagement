using System.Data;
using Library.Models.Request;
using Library.Models.Response;

namespace Library.Business.Interface
{
    public interface ILoginUserBusiness{
        Task<LoginUserResponse> LoginUser(LoginUserModel.LoginUserUIModel loginUserUIModel);
    }
}
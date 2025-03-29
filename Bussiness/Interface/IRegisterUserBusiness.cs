using System.Data;
using Library.Models.Request;
using Library.Models.Response;

namespace Library.Business.Interface
{
    public interface IRegisterUserBusiness{
        Task RegisterUser(RegisterUserModel.RegisterUserUIModel registerUserUIModel);
    }
}
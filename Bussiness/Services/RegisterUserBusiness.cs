using System.Data;
using Library.Business.Interface;
using Library.Exceptions.CustomExceptions;
using Library.Middleware;
using Library.Models.Request;
using Library.Models.Response;
using Library.Repository;
using Library.Utility.DBConstants;

namespace Library.Business.Services
{
    public class RegisterUserBusiness : IRegisterUserBusiness
    {
        private readonly IExecuteStoredProcedure _executeStoredProcedure;

        public RegisterUserBusiness(IExecuteStoredProcedure executeStoredProcedure, TokenService tokenService){
            _executeStoredProcedure = executeStoredProcedure;
        }
        public async Task RegisterUser(RegisterUserModel.RegisterUserUIModel registerUserUIModel)
        {
            RegisterUserModel.RegisterUserDBModel user = new RegisterUserModel.RegisterUserDBModel{
                FirstName = registerUserUIModel.FirstName,
                LastName = registerUserUIModel.LastName,
                Email = registerUserUIModel.Email,
                PasswordHash = PasswordHasher.HashPassword(registerUserUIModel.Password),
                Mobile = registerUserUIModel.Mobile,
                Address = registerUserUIModel.Address ?? "",
                Role = "User",
                HasSubscription = false,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            await _executeStoredProcedure.CallStoredProcedure<RegisterUserModel.RegisterUserDBModel>(StoredProcedureConstants.REGISTER_USER, user, false);

        }
    }
}
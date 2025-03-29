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
    public class LoginUserBusiness : ILoginUserBusiness
    {
        private readonly IExecuteStoredProcedure _executeStoredProcedure;

        private readonly TokenService _tokenService;
        public LoginUserBusiness(IExecuteStoredProcedure executeStoredProcedure, TokenService tokenService){
            _executeStoredProcedure = executeStoredProcedure;
            _tokenService = tokenService;
        }
        public async Task<LoginUserResponse> LoginUser(LoginUserModel.LoginUserUIModel loginUserUIModel)
        {
            DataSet ds = new DataSet();

            LoginUserModel.LoginUserDBModel user = new LoginUserModel.LoginUserDBModel{
                Email = loginUserUIModel.Email
            };

            ds = await _executeStoredProcedure.CallStoredProcedure<LoginUserModel.LoginUserDBModel>(StoredProcedureConstants.LOGIN_USER, user, false);
            
            bool res = PasswordHasher.VerifyPassword(loginUserUIModel.Password, (ds.Tables[0].Rows[0]["PasswordHash"].ToString() ?? "").Trim());

            LoginUserModel.TokenGenerationModel tokenGeneration = new LoginUserModel.TokenGenerationModel{
                Email = loginUserUIModel.Email,
                UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"]),
                Role = ds.Tables[0].Rows[0]["Role"].ToString() ?? "User"
            };


            try{
                if(res){
                    LoginUserResponse token = await _tokenService.GenerateToken(tokenGeneration);
                    return token;
                }
                else{
                    throw new UnauthorizedException("Unauthorized Access!");
                }

            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
    }
}
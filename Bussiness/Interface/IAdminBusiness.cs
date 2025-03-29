using System.Data;
using Library.Models.Request;

namespace Library.Business.Interface
{
    public interface IAdminBusiness{
        Task<DataSet> GetALlUsers();
    }
}
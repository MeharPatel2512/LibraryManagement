using System.Data;

namespace Library.Repository
{
    public interface IExecuteStoredProcedure{
        Task<DataSet> CallStoredProcedure<T> (string StoredProcedure, T Parameters, bool is_with_userId);
        Task<Boolean> CallNonQueryStoredProcedure<T>(string StoredProcedure, T Parameters, bool is_with_userId);

    } 
}
using AuthAPI.Data.DataModels;
using System.Threading.Tasks;

namespace AuthAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> ValidateUser(string username, string password);
    }
}

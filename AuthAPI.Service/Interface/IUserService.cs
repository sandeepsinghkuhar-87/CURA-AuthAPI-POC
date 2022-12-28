using AuthAPI.Data.DataModels;
using System.Threading.Tasks;

namespace AuthAPI.Service.Interface
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}

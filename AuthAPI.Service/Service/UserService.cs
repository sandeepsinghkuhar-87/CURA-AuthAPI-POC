using AuthAPI.Data.DataModels;
using AuthAPI.Repository.Interface;
using AuthAPI.Service.Interface;
using System;
using System.Threading.Tasks;

namespace AuthAPI.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await _repository.ValidateUser(username, password);
        }
    }
}

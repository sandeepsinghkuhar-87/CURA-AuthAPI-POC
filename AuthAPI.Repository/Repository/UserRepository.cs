using AuthAPI.Data.DataModels;
using AuthAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Options;

namespace AuthAPI.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IList<User> _users;

        public UserRepository(IOptions<List<User>> usersData)
        {
            _users = usersData.Value;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            var user = _users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower())
                            .SingleOrDefault();

            return await Task.FromResult(user);
        }
    }
}

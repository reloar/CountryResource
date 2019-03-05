using CountryResource.DomainModels;
using CountryResource.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.Infrastructure.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepo;
        public UserManager(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public Task<(bool Status, string Message)> CreateUser(UserModel model)
        {
            return _userRepo.CreateUser(model);
        }

      

        public Task<UserModel> Verifyuser(string username, string password)
        {
            return _userRepo.Verifyuser(username, password);
        }
    }
}

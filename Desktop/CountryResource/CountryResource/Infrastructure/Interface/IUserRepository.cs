using CountryResource.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.Infrastructure.Interface
{
    public interface IUserRepository
    {
        Task<(bool Status, string Message)> CreateUser(UserModel model);
        Task<UserModel> Verifyuser(string username, string password);
       
    }
}

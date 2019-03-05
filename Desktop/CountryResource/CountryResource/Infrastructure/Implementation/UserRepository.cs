using CountryResource.DomainModels;
using CountryResource.Entities;
using CountryResource.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace CountryResource.Infrastructure.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly DbContext _context;
        public UserRepository(DbContext context)
        {
            _context = context;

        }


        public async Task<(bool Status, string Message)> CreateUser(UserModel model)
        {
            var user = new User().Assign(model);
          
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(model.password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.Passwordsalt = passwordSalt;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();


            return (true, "Created");
        }
        public async Task<UserModel> Verifyuser(string username, string password)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == username);

            if (user == null)
                return null;
            if (!verifyPasswordHash(password, user.PasswordHash, user.Passwordsalt))
                return null;
            var model = new UserModel().Assign(user);
            return model;
        }
        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordsalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

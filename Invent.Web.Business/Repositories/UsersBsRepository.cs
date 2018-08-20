using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public class UsersBsRepository : GenericRepository<Users>, IUsersBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public UsersBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task<Users> CreateAsync(Users user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_dbContext.Users.Any(x => x.Email == user.Email))
                throw new Exception("Email Address " + user.Email + " is already in the database!");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);
            _dbContext.SaveChanges();

            return user;
        }

        public async Task UpdateAsync(Users userParam, string password = null)
        {
            var user = (from item in _dbContext.Users
                        where item.Email == userParam.Email
                        select item)?.FirstOrDefault();

            if (user == null)
                throw new Exception("User not found");

            if (userParam.Email != user.Email)
            {
                if (_dbContext.Users.Any(x => x.Email == userParam.Email))
                    throw new Exception("Email Address " + user.Email + " is already in the database!");
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Email = userParam.Email;

            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = (from item in _dbContext.Users
                        where item.UserId == id
                        select item)?.FirstOrDefault();

            if (user == null)
                throw new Exception("User not found");

            user.IsActive = false;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Users> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await Task.Run(() =>
            {
                return _dbContext.Users.SingleOrDefault(x => x.Email == username && x.IsActive);
            });

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

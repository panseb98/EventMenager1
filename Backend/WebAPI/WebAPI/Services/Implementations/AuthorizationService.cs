using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

using WebAPI.Database;
using WebAPI.Models.Authorization.Dto;
using WebAPI.Models.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly DataContext _context;
        public AuthorizationService(DataContext context)
        {
            _context = context;
        }

        public async Task<LoggedUser> Login(Login userLoginModel)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username.ToLower() == userLoginModel.Username.ToLower());
            if (user == null)
                return null;
            if (!VerifyPasswordHash(userLoginModel.Password, user.Password, user.PasswordSalt))
                return null;
            return new LoggedUser() { Username = user.Username, Name = user.Name, UserId = user.Id };

        }

        public Task<bool> LogOff(string userName)
        {/*
            var user = _context.User.Where(x => x.Username.ToLower() == userName.ToLower());
            if (user == null)
                return null;*/
            return null;

        }
        [HttpPost("register")]
        public async Task<LoggedUser> Register(Registration userRegistrationModel)
        {
            User newUser = new User(userRegistrationModel);
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userRegistrationModel.Password, out passwordHash, out passwordSalt);
            newUser.Password = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return await Login(new Login() { Username = newUser.Username, Password = userRegistrationModel.Password});

        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i]) return false;

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

        public async Task<bool> UserExists(string userName)
        {
           int count = await _context.User.CountAsync(x => x.Username == userName);
            if (count == 0) return false;
            return true;

        }

        public async Task<List<UserToList>> GetUsers()
        {
            var s = _context.User.Select(x => new UserToList() { UserId = x.Id, City = x.City, Name = x.Name, Surname = x.Surname });
            return await s.ToListAsync();
        }

        public async Task<UserProfile> GetUser(int userId)
        {
            var users = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
            return new UserProfile() { City = users.City, Email = users.Email, Name = users.Name, UserId = users.Id, SurName = users.Surname, UserName = users.Username };
        }
    }
}

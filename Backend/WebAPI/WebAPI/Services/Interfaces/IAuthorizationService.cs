using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization.Dto;

namespace WebAPI.Services.Interfaces
{
    public interface IAuthorizationService
    {
         Task<LoggedUser> Login(Login userLoginModel);
         Task<LoggedUser> Register(Registration userRegistrationModel);
         Task<List<UserToList>> GetUsers();
         Task<UserProfile> GetUser(int userId);
         Task<bool> LogOff(string userName);
         Task<bool> UserExists(string userName);
    }
}

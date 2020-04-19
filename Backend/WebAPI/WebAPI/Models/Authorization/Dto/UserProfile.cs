using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Authorization.Dto
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public List<UserToList> Friends { get; set; }
    }
}

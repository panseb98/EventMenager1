using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Authorization.Dto
{
    public class LoggedUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization.Dto;

namespace WebAPI.Models.Authorization
{
    public class User
    {
        [Column("USER_ID")]
        public int Id { get; set; }

        [Column("USER_NAME")]
        public string Name { get; set; }

        [Column("USER_SURNAME")]
        public string Surname { get; set; }

        [Column("USER_NICK")]
        public string Username { get; set; }

        [Column("USER_EMAIL")]
        public string Email { get; set; }

        [Column("USER_PASSWORD")]
        public byte[] Password { get; set; }

        [Column("USER_PASSWORD_SALT")]
        public byte[] PasswordSalt { get; set; }

        [Column("USER_BIRTH")]
        public DateTime BirthDate { get; set; }

        [Column("USER_CITY")]
        public string City { get; set; }
        public User(Registration model)
        {
            City = model.City;
            BirthDate = model.BirthDate;
            Email = model.Email;
            Name = model.Name;
            Surname = Surname;
            Username = model.Username;

        }
        public User()
        {

        }

    }
}

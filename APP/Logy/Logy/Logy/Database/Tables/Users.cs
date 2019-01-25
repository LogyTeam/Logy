using Logy.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Database.Tables
{
    [Table("USERS")]
    public class Users : LogyTable<User>
    {
        [PrimaryKey, AutoIncrement]
        public int idUSER { get; set; }
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(512)]
        public string Password { get; set; }

        public override User CreateObject()
        {
            return new User(idUSER ,this.Email, this.Username);
        }
    }
}

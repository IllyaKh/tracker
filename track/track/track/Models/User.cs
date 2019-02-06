using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public override string ToString()
        {
            return (this.Surname + "(" + this.Name+ ")");
        }
        public string GetLogin()
        {
            return this.Login;
        }
        public string GetPassword()
        {
            return this.Password;
        }
        
    }
}

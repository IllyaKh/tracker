using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get;set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        private string color = "#1c74da";
        public string Coloro
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        

        public override string ToString()
        {
            return $"{this.Login}: {this.Password}";
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

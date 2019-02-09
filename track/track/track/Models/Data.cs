using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace track.Models
{
    class Data:User
    {
        [PrimaryKey]
        public int Identif { get; set; }
        public int UserId { get; set; }
        public int SugarNow { get; set; }

        public string ToString(int local)
        {
            if (local == 1)
                return Convert.ToString(this.Identif);
            else if (local == 2)
                return Convert.ToString(this.UserId);
            else if (local == 3)
                return Convert.ToString(this.SugarNow);
            return "xy";
        }

        public void BindingId(int idUser)
        {
            this.UserId = idUser;
        }


    }
}
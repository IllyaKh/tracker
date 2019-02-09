using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace track.Models
{
    class Data:User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SugarNow { get; set; }

        public override string ToString(string local)
        {
            if (local == Convert.ToString(Id))
                return (this.Id);
            else if (local == Convert.ToString(UserId))
                return Convert.ToSring(this.UserId);
            else if (local == Convert.ToString(SugarNow))
                return Convert.ToString(this.SugarNow);
        }

        public void BindingId(int idUser)
        {
            this.UserId = idUser;
        }


    }
}
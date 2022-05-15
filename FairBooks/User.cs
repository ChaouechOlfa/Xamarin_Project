using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FairBooks
{
    [Table("people")]
   public class User
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set;}
        public String Name { get; set; }
        public String Password { get; set; }
       
    }
}

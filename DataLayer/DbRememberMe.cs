using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace TEFL_App.DataLayer
{
    public class DbRememberMe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public int Type { get; set; }
        [NotNull]
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace TEFL_App.DataLayer
{
    public class DbAppSettings
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        [NotNull]
        public string CultureInfo { get; set; } = "zh-CH";
        
    }
}

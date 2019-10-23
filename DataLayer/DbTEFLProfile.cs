using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEFL_App.DataLayer
{
    public class DbTEFLProfile
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public int CandidateID { get; set; }
        public string AppUsername { get; set; } = "";
        public string AppPassword { get; set; } = "";
    }
}

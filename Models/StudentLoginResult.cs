using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEFL_App.Models
{
    public class StudentLoginResult
    {
        public TEFLProfile Student { get; set; }
        public Employer Manager { get; set; }
    }
}

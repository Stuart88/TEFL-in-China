using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEFL_App.Models
{
    public class ManagerLoginResult
    {
        public Employer User { get; set; }
        public List<TEFLProfile> TEFLProfiles { get; set; }
    }
}

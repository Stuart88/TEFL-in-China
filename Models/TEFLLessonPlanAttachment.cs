using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEFL_App.Models
{
    public class TEFLLessonPlanAttachment : HttpPostable
    {
        public DateTime? CreationDate { get; set; }
        public int ID { get; set; }
        public int TEFLProfileID { get; set; }
        public string DiskLocation { get; set; }
        public string WebLocation { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] file { get; set; }
    }
}

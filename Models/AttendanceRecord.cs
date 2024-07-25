using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAMS_csv_To_xlsx.Models
{
    internal class AttendanceRecord
    {
        public string Data { get; set; }
        public string File { get; set; }
        public List<string> Presentes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamTinHoc.Models
{
    public class Schedule
    {
        public string ScheduleID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ClassroomID { get; set; }
    }
}

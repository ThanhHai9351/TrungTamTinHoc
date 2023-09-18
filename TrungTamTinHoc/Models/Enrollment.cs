using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamTinHoc.Models;

namespace TrungTamTinHoc.Models
{
    public class Enrollment
    {
        public string EnrollmentID { get; set; }

        public string StudentID { get; set; }

        public string TeacherID { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }
        
        public virtual Courses Courses { get; set; }

    }
}

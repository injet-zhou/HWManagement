using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Enrollment
    {
        public string EnrollmentId { get; set; }
        public string OpenId { get; set; }
        public string CourseId { get; set; }
        public int? Score { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Open { get; set; }
    }
}

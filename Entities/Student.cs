using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Student
    {
        public Student()
        {
            Enrollment = new HashSet<Enrollment>();
            Submission = new HashSet<Submission>();
        }

        public string OpenId { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Sclass { get; set; }
        public string Phone { get; set; }
        public string School { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Submission> Submission { get; set; }
    }
}

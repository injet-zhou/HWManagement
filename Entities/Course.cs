using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Course
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
            Homework = new HashSet<Homework>();
        }

        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Homework> Homework { get; set; }
    }
}

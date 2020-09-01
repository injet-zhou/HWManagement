using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public string OpenId { get; set; }
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string School { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}

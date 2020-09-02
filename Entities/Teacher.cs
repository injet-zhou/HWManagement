using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Course = new HashSet<Course>();
        }

        public string OpenId { get; set; }
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
        public string Avatar { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}

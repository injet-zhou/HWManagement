using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Homework
    {
        public Homework()
        {
            Submission = new HashSet<Submission>();
        }

        public string HomeworkId { get; set; }
        public string CourseId { get; set; }
        public string Name { get; set; }
        public DateTime? Due { get; set; }
        public DateTime? Created { get; set; }
        public int? Published { get; set; }
        public int? Mulsubmit { get; set; }
        public string Content { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Submission> Submission { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Submission
    {
        public string SubmissionId { get; set; }
        public string ResourceId { get; set; }
        public string HomeworkId { get; set; }
        public string OpenId { get; set; }
        public string CourseId { get; set; }
        public DateTime? SubTime { get; set; }
        public int? Score { get; set; }
        public string Content { get; set; }

        public virtual Course Course { get; set; }
        public virtual Homework Homework { get; set; }
        public virtual Student Open { get; set; }
        public virtual Resource Resource { get; set; }
    }
}

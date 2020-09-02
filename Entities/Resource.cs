using System;
using System.Collections.Generic;

namespace HW.Entities
{
    public partial class Resource
    {
        public Resource()
        {
            Submission = new HashSet<Submission>();
        }

        public string ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public int? Size { get; set; }

        public virtual ICollection<Submission> Submission { get; set; }
    }
}

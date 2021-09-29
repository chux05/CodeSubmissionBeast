using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public class Submission
    {
        public int Id { get; set; }

        public string PersonEmail { get; set; }
        public Answer Answer { get; set; }

        public DateTime DateCompleted { get; set; }
    }
}

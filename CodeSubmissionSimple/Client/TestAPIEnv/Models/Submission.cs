using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Client.TestAPIEnv.Models
{
    public class Submission
    {
        public int Id { get; set; }

        public string PersonEmail { get; set; }

        public DateTime DateCompleted { get; set; }
    }
}

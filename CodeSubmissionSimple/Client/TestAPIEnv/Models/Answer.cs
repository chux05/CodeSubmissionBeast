using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Client.TestAPIEnv.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string AnswerEntered { get; set; }

        public string Question { get; set; }

        public int SubmissionId { get; set; }

        public Submission Submission { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public class SubmissionSample
    {        
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionDescription { get; set; }
        
        [Required]
        public string Answer { get; set; }
        
    }
}
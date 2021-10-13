using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Client.ClientTestEnv.Models;

namespace CodeSubmissionSimple.Client.ClientTestEnv.Utils
{
    public class State
    {
        public List<SubmissionSample> Submissions { get; set; } = new List<SubmissionSample>();   

        public int Count { get; set; } = 1;     

        public bool IsSaved { get; set; }
        
    }
}
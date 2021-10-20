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

        public bool isSaved { get; set; }

        public string Q4template = @$"public class Animal
{{
    public string Eat()
    {{
        return ""Yummy"";
    }}

    public virtual string MakeNoise()
    {{
        return ""Durrr"";
    }}
 }}

class Horse
{{
    string Eat()
    {{
        return ""Yummy"";
    }}

    string MakeNoise()
    {{
        return ""Neigh"";
    }}
}}

class Sheep
{{
    string Eat()
    {{
        return ""Yummy"";
    }}

    string MakeNoise()
    {{
        return ""Baaah"";
    }}
}}
    ";

    }
}
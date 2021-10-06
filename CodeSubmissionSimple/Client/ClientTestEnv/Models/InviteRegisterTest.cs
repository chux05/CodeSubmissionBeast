using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Client.ClientTestEnv.Models
{
    public class InviteRegisterTest
    {
        [Display(Name = "Full Name")]
        [Required]        
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; } = "P@ssword1";

        public string Role { get; set; } = "Candidate";

    }
}
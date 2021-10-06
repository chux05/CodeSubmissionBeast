using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Shared;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public interface IWorkOfUnit : IDisposable
    {

        IEncompassingRepository<AppUser> AppUsers { get; }
        IEncompassingRepository<Answer> Answers { get; }

        IEncompassingRepository<Submission> Submissions { get; }

        IEncompassingRepository<SubmissionSample> SubmissionSamples { get; }

        Task Save();

    }
}

using CodeSubmissionSimple.Server.TestEnvironment.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.TestEnvironment.Repositories
{
    public class SSampleTest : EncompassingRepository<SubmissionSample>, ISampleTest
    {
        public SSampleTest(AppDbContext context) : base(context)
        {
        }

        public async Task GetAllEmailGrouped()
        {
            var dateAndUsername =  _context.SubmissionSamples
    .Select(x => new { x.UserEmail})
    .ToListAsync();

           
            var query = from p in _context.SubmissionSamples
                        group p by p.UserEmail into emails
                        select emails;
              await query.AsNoTracking().ToListAsync();
        }
    }
}

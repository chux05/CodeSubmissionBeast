using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Server.Data;
using CodeSubmissionSimple.Server.IRepositories;
using CodeSubmissionSimple.Shared;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public class WorkOfUnit : IWorkOfUnit
    {
        private readonly AppDbContext _context;

        private IEncompassingRepository<AppUser> _appusers;
        private IEncompassingRepository<Submission> _submissions;
        private IEncompassingRepository<Answer> _answers;
        public WorkOfUnit(AppDbContext context)
        {
            _context = context;
        }

       

        public IEncompassingRepository<AppUser> AppUsers => _appusers ??= new EncompassingRepository<AppUser>(_context);

        public IEncompassingRepository<Answer> Answers => _answers ??= new EncompassingRepository<Answer>(_context);

        public IEncompassingRepository<Submission> Submissions => _submissions ??= new EncompassingRepository<Submission>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}

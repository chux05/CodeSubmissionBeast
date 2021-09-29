using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Server.Data;
using CodeSubmissionSimple.Server.IRepositories;
using CodeSubmissionSimple.Shared;

namespace CodeSubmissionSimple.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IGenericRepository<AppUser> _appusers;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public IGenericRepository<AppUser> AppUsers => _appusers ??= new GenericRepository<AppUser>(_context);

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

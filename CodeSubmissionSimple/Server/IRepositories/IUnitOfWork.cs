using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Shared;

namespace CodeSubmissionSimple.Server.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<AppUser> AppUsers { get; }

        Task Save();

    }
}

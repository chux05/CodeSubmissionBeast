using CodeSubmissionSimple.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public interface IUserDb
    {
        Task<AppUser> AuthenticateUser(string email, string password);

        Task<AppUser> AddUser(string email, string password, string role);
    }
}

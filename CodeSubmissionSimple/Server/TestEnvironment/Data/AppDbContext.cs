using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeAnswerSimple.Server.TestEnvironment;
using CodeSubmissionSimple.Shared;
using Microsoft.EntityFrameworkCore;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<SubmissionSample> SubmissionSamples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

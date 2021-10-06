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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    Email = "ashton@gmail.com",
                    Role = "Admin",
                    PasswordHash = "1254wsde9632fgty"
                },
                 new AppUser
                 {
                     Id = 2,
                     Email = "hi@ngn.com",
                     Role = "Developer",
                     PasswordHash = "1254wsdeu9632fgty"
                 }
                );


            modelBuilder.Entity<Submission>().HasData(
                new Submission
                {
                    Id = 1,
                    PersonEmail = "test@test.com",
                    DateCompleted = DateTime.Now
                }
           );

            modelBuilder.ApplyConfiguration(new AnswerConfiguration());

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Shared;
using Microsoft.EntityFrameworkCore;

namespace CodeSubmissionSimple.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<AppUser> AppUser { get; set; }

       

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
        }
    }
}

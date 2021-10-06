using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Server.TestEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CodeSubmissionSampleSimple.Server.TestEnvironment
{
    public class SubmissionSampleConfiguration : IEntityTypeConfiguration<SubmissionSample>
    {
        public void Configure(EntityTypeBuilder<SubmissionSample> builder)
        {
            builder.HasData(

                new SubmissionSample
                {
                    Id = 1,
                    QuestionNumber = 1,
                    UserEmail = "gajo@email.com",
                    QuestionTitle = "Question 1",
                    QuestionDescription = "Please see attached ERD image",
                    Answer = "I would crawl in a hole"
                },
                 new SubmissionSample
                 {
                     Id = 2,
                     QuestionNumber = 2,
                     UserEmail = "gajo@email.com",
                     QuestionTitle = "Question 2 Databases",
                     QuestionDescription = "Write a sql query",
                     Answer = "Select * FROM home"
                 },
                  new SubmissionSample
                  {
                      Id = 3,
                      QuestionNumber = 3,
                      UserEmail = "gajo@email.com",
                      QuestionTitle = "Question 3- C# code",
                      QuestionDescription = "Print StackOverflow",
                      Answer = "Stack Stack Stacky"
                  },
                   new SubmissionSample
                   {
                       Id = 4,
                       QuestionNumber = 4,
                       UserEmail = "gajo@email.com",
                       QuestionTitle = "Question 4 - Refactoring",
                       QuestionDescription = "There is a cow horse and sheep",
                       Answer = "Nee man"
                   },
                    new SubmissionSample
                    {
                        Id = 5,
                        QuestionNumber = 5,
                        UserEmail = "gajo@email.com",
                        QuestionTitle = "Question 5 - Front End",
                        QuestionDescription = "Do some frontend studd",
                        Answer = "document.getelementbyid()"
                    },
                     new SubmissionSample
                     {
                         Id = 6,
                         QuestionNumber = 6,
                         UserEmail = "gajo@email.com",
                         QuestionTitle = "Question 6 - Front End",
                         QuestionDescription = "Implement the Javascript function",
                         Answer = "I failed already"
                     }
            );
        }
    }
}
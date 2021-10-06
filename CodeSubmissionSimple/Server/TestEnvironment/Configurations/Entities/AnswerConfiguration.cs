using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Server.TestEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CodeAnswerSimple.Server.TestEnvironment
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(

                new Answer
                {
                    Id = 1,
                    Question = "Please see the attached ERD diagram image. The diagram was submitted as a solution to storing employee Cellphone data, voice and sms usage. Discuss at least one improvement that can be done to the ERD.",
                    SubmissionId = 1,
                    AnswerEntered = "ERD Answer"
                },
                 new Answer
                 {
                     Id = 2,
                     Question = "An analyst has asked you to run a query to see the number of movie tickets per genre that was sold in December last year.The data he needs is spread across two tables.",
                     SubmissionId = 1,
                     AnswerEntered = "Select * from Hello"
                 },
                  new Answer
                  {
                      Id = 3,
                      Question = "An analyst has asked you to run a query to see the number of movie tickets per genre that was sold in December last year.The data he needs is spread across two tables.",
                     SubmissionId = 1,
                      AnswerEntered = "Select * from Hello"
                  },
                   new Answer
                   {
                       Id = 4,
                       Question = $@"Write a C# method that will take, as input, a string and dependent on the string length prints out the following:

If the length is a multiple of 2 your method must print out ""Stack""
If the length is a multiple of 4 your method must print out ""Overflow""
If the length is a multiple of 2 and 4 your method must print out ""Stack Overflow!"" ",
                       SubmissionId = 1,
                       AnswerEntered = "Oh gosht this is long"
                   },
                    new Answer
                    {
                        Id = 5,
                        Question = $@"This task is about code refactoring. Below you are given classes Animal, Horse and Sheep.

You need to refactor Horse and Sheep as you see fit.The goal is to make the classes more maintainable.You should apply any principles or patterns you think are necessary.

Don\'t make any change to the properties (methods) of the class Animal.",
                        SubmissionId = 1,
                        AnswerEntered = "SOme C# code"
                    },
                     new Answer
                     {
                         Id = 6,
                         Question = $@"1. What will the colour of both div elements be?
2. How would you dynamically target firstDiv and make it's colour pink? (provide the code snippet)
3. How would you dynamically target secondDiv and add the yellow-card class to its class list? (provide the code snippet)",
                         SubmissionId = 1,
                         AnswerEntered = "document.getElementById..."
                     },
                     new Answer
                     {
                         Id = 7,
                         Question = $@"Why will the function be parsed correctly?
How could you introduce a stricter syntax to variable / function declaration and avoid this behaviour",
                         SubmissionId = 1,
                         AnswerEntered = "Some Javascript work"
                     }
            );
        }
    }
}
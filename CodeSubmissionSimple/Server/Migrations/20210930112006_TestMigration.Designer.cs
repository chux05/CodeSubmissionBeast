﻿// <auto-generated />
using System;
using CodeSubmissionSimple.Server.TestEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeSubmissionSimple.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210930112006_TestMigration")]
    partial class TestMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("CodeSubmissionSimple.Server.TestEnvironment.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerEntered")
                        .HasColumnType("TEXT");

                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerEntered = "ERD Answer",
                            Question = "Please see the attached ERD diagram image. The diagram was submitted as a solution to storing employee Cellphone data, voice and sms usage. Discuss at least one improvement that can be done to the ERD.",
                            SubmissionId = 1
                        },
                        new
                        {
                            Id = 2,
                            AnswerEntered = "Select * from Hello",
                            Question = "An analyst has asked you to run a query to see the number of movie tickets per genre that was sold in December last year.The data he needs is spread across two tables.",
                            SubmissionId = 1
                        },
                        new
                        {
                            Id = 3,
                            AnswerEntered = "Select * from Hello",
                            Question = "An analyst has asked you to run a query to see the number of movie tickets per genre that was sold in December last year.The data he needs is spread across two tables.",
                            SubmissionId = 1
                        },
                        new
                        {
                            Id = 4,
                            AnswerEntered = "Oh gosht this is long",
                            Question = "Write a C# method that will take, as input, a string and dependent on the string length prints out the following:\r\n\r\nIf the length is a multiple of 2 your method must print out \"Stack\"\r\nIf the length is a multiple of 4 your method must print out \"Overflow\"\r\nIf the length is a multiple of 2 and 4 your method must print out \"Stack Overflow!\" ",
                            SubmissionId = 1
                        },
                        new
                        {
                            Id = 5,
                            AnswerEntered = "SOme C# code",
                            Question = "This task is about code refactoring. Below you are given classes Animal, Horse and Sheep.\r\n\r\nYou need to refactor Horse and Sheep as you see fit.The goal is to make the classes more maintainable.You should apply any principles or patterns you think are necessary.\r\n\r\nDon\\'t make any change to the properties (methods) of the class Animal.",
                            SubmissionId = 1
                        },
                        new
                        {
                            Id = 6,
                            AnswerEntered = "document.getElementById...",
                            Question = "1. What will the colour of both div elements be?\r\n2. How would you dynamically target firstDiv and make it's colour pink? (provide the code snippet)\r\n3. How would you dynamically target secondDiv and add the yellow-card class to its class list? (provide the code snippet)",
                            SubmissionId = 1
                        },
                        new
                        {
                            Id = 7,
                            AnswerEntered = "Some Javascript work",
                            Question = "Why will the function be parsed correctly?\r\nHow could you introduce a stricter syntax to variable / function declaration and avoid this behaviour",
                            SubmissionId = 1
                        });
                });

            modelBuilder.Entity("CodeSubmissionSimple.Server.TestEnvironment.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonEmail")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Submissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCompleted = new DateTime(2021, 9, 30, 13, 20, 6, 370, DateTimeKind.Local).AddTicks(5929),
                            PersonEmail = "test@test.com"
                        });
                });

            modelBuilder.Entity("CodeSubmissionSimple.Shared.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUser");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ashton@gmail.com",
                            PasswordHash = "1254wsde9632fgty",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "hi@ngn.com",
                            PasswordHash = "1254wsdeu9632fgty",
                            Role = "Developer"
                        });
                });

            modelBuilder.Entity("CodeSubmissionSimple.Server.TestEnvironment.Answer", b =>
                {
                    b.HasOne("CodeSubmissionSimple.Server.TestEnvironment.Submission", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });
#pragma warning restore 612, 618
        }
    }
}

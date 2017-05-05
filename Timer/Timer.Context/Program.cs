// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Timer.Context.Context;
using Timer.Context.Models;

namespace Timer.Context
{
    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            using (var context = new TimerDbEntities())
            {
                var dept = new Department
                {
                    DepartmentName = "IT",
                    DepartmentEmail = "dev@hello.dk"
                };

                var proj = new Project
                {
                    ProjectName = "Timer",
                    ProjectDescription = "Time registration project",
                    Times = new List<Time>(),
                    Users = new List<User>()
                };

                var user = new User
                {
                    Firstname = "Stoyan",
                    Lastname = "Bonchev",
                    Account = "H000001",
                    Email = "stoyan@home.net",
                    IsAdmin = true,
                    Password = "1234",
                    Department = dept,
                    Projects = new List<Project> { proj },
                };

                var time = new Time
                {
                    WorkDate = DateTime.Now,
                    StartTime = "08",
                    EndTime = "16",
                    Break = 30,
                    Note = "Simple note",
                    Projects = new List<Project> { proj },
                    Users = new List<User> { user }
                };

                var log = new Logging
                {
                    CreatedAt = "14-10-2016",
                    LoggerName = "Test",
                    MachineName = Environment.MachineName,
                    Message = "Creating the tables...",
                    Exception = "No exceptions....",
                    StackTrace = "Test...",
                    UserName = Environment.UserName
                };

                context.DepartmentEntity.Add(dept);
                context.ProjectEntity.Add(proj);
                context.TimeEntity.Add(time);
                context.UserEntity.Add(user);
                context.LoggingEntity.Add(log);
                context.SaveChanges();

                Console.WriteLine("The database is created, so not use Main[] anymore");
                Console.ReadLine();
            }
        }
    }
}

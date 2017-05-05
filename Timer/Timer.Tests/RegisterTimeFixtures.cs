// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterTimeFixtures.cs" company="">
//   Time tests
// </copyright>
// <summary>
//   The register time fixtures.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timer.Context.Models;
using Timer.Wcf.DataMembers;
using Timer.Wcf.Factory;
using Timer.Wcf.Repositories;

namespace Timer.Tests
{
    /// <summary>
    /// The register time fixtures.
    /// </summary>
    [TestClass]
    public class RegisterTimeFixtures
    {
        /// <summary>
        /// The can_register_time_in_database.
        /// </summary>
        [TestMethod]
        public void Can_register_time_in_database()
        {
            var data = new TimeDataMember
            {
                WorkDate = DateTime.Now,
                StartTime = "7",
                EndTime = "15",
                Note = "Lorem Ipsum",
                Break = 30,
                Projects = new List<Project> { new Project { ProjectName = "Hello", ProjectDescription = "The Hello project" } },
                Users = new List<User> { new User { Firstname = "Lorem", Lastname = "Ipsum" } }
            };

            var repo = new TimeRepository(new DependencyFactory());
            var testable = repo.AddTime(data);

            testable.Should().BeTrue();
        }

        /// <summary>
        /// Can get time from database.
        /// </summary>
        [TestMethod]
        public void Can_get_time_from_database()
        {
            var repo = new TimeRepository(new DependencyFactory());
            var testable = repo.RetrieveTime(1);

            testable.Should().NotBeNull();
        }

        /// <summary>
        /// Can delete time from database.
        /// </summary>
        [TestMethod]
        public void Can_delete_time_from_database()
        {
            var repo = new TimeRepository(new DependencyFactory());
            var testable = repo.RemoveTime(1);

            testable.Should().BeTrue();
        }
    }
}

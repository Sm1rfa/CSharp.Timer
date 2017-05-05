// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDataMember.cs" company="Timer Project">
//   Timer Project
// </copyright>
// <summary>
//   Defines the UserDataMember type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using Timer.Context.Models;

namespace Timer.Wcf.DataMembers
{
    /// <summary>
    /// The user data member.
    /// </summary>
    [DataContract]
    public class UserDataMember
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [DataMember]
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [DataMember]
        public string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        [DataMember]
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is admin.
        /// </summary>
        [DataMember]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        [DataMember]
        public List<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        [DataMember]
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the times.
        /// </summary>
        [DataMember]
        public List<Time> Times { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        [DataMember]
        public string FullName { get; set; }
    }
}
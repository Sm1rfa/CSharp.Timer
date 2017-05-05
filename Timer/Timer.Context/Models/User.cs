// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timer.Context.Models
{
    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Projects = new List<Project>();
            this.Times = new List<Time>();
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is admin.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public ICollection<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the times.
        /// </summary>
        public ICollection<Time> Times { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        public Department Department { get; set; }
    }
}

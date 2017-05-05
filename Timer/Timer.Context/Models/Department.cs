// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Department.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the Department type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timer.Context.Models
{
    /// <summary>
    /// The department.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Department"/> class.
        /// </summary>
        public Department()
        {
            this.Users = new List<User>();
        }

        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department name.
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the department email.
        /// </summary>
        public string DepartmentEmail { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public ICollection<User> Users { get; set; }
    }
}

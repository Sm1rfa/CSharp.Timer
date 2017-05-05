// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the Project type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timer.Context.Models
{
    /// <summary>
    /// The project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        public Project()
        {
            this.Users = new List<User>();
            this.Times = new List<Time>();
        }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public string ProjectDescription { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public ICollection<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public ICollection<Time> Times { get; set; }
    }
}

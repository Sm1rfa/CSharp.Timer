// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Time.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the Time type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timer.Context.Models
{
    /// <summary>
    /// The time.
    /// </summary>
    public class Time
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        public Time()
        {
            this.Projects = new List<Project>();
            this.Users = new List<User>();
        }

        /// <summary>
        /// Gets or sets the time id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeId { get; set; }

        /// <summary>
        /// Gets or sets the work date.
        /// </summary>
        public DateTime WorkDate { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets the break.
        /// </summary>
        public int Break { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public ICollection<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public ICollection<User> Users { get; set; }
    }
}

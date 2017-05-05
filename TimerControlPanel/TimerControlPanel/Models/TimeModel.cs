// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeModel.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the TimeModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using TimerControlPanel.Connected_Services.TimerService;

namespace TimerControlPanel.Models
{
    /// <summary>
    /// The time model.
    /// </summary>
    public class TimeModel
    {
        /// <summary>
        /// Gets or sets the time id.
        /// </summary>
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
        /// Gets or sets the user id.
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public List<Project> Projects { get; set; }
    }
}

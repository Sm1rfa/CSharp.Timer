// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectModel.cs" company="Timer Service">
//   Timer Service
// </copyright>
// <summary>
//   The project model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TimerControlPanel.Connected_Services.TimerService;

namespace TimerControlPanel.Models
{
    /// <summary>
    /// The project model.
    /// </summary>
    public class ProjectModel
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
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
        public List<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public List<Time> Times { get; set; }
    }
}

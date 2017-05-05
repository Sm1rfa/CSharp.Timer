// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentModel.cs" company="Time Register Client">
//   Time Register Client
// </copyright>
// <summary>
//   The department model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TimerControlPanel.Connected_Services.TimerService;

namespace TimerControlPanel.Models
{
    /// <summary>
    /// The department model.
    /// </summary>
    public class DepartmentModel
    {
        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
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
        public List<User> Users { get; set; }
    }
}

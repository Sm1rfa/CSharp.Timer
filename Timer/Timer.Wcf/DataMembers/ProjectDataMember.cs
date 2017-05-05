// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectDataMember.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the ProjectDataMember type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using Timer.Context.Models;

namespace Timer.Wcf.DataMembers
{
    /// <summary>
    /// The project data member.
    /// </summary>
    [DataContract]
    public class ProjectDataMember
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        [DataMember]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        [DataMember]
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        [DataMember]
        public string ProjectDescription { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        [DataMember]
        public List<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the times.
        /// </summary>
        [DataMember]
        public List<Time> Times { get; set; }
    }
}
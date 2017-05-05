// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeDataMember.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the TimeDataMember type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Timer.Context.Models;

namespace Timer.Wcf.DataMembers
{
    /// <summary>
    /// The time data member.
    /// </summary>
    [DataContract]
    public class TimeDataMember
    {
        /// <summary>
        /// Gets or sets the time id.
        /// </summary>
        [DataMember]
        public int TimeId { get; set; }

        /// <summary>
        /// Gets or sets the work date.
        /// </summary>
        [DataMember]
        public DateTime WorkDate { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        [DataMember]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        [DataMember]
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets the break.
        /// </summary>
        [DataMember]
        public int Break { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        [DataMember]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        [DataMember]
        public List<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        [DataMember]
        public List<User> Users { get; set; }
    }
}
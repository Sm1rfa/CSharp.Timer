// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentDataMember.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the DepartmentDataMember type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using Timer.Context.Models;

namespace Timer.Wcf.DataMembers
{
    /// <summary>
    /// The department data member.
    /// </summary>
    [DataContract]
    public class DepartmentDataMember
    {
        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
        [DataMember]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department name.
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the department email.
        /// </summary>
        [DataMember]
        public string DepartmentEmail { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        [DataMember]
        public List<User> Users { get; set; }
    }
}
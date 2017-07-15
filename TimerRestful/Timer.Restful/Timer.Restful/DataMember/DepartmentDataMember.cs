using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timer.Restful.DataMember
{
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
        public List<UserDataMember> Users { get; set; }
    }
}
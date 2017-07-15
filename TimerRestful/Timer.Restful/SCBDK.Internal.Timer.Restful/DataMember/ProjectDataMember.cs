using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timer.Restful.DataMember
{
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
        public List<UserDataMember> Users { get; set; }

        /// <summary>
        /// Gets or sets the times.
        /// </summary>
        [DataMember]
        public List<TimeDataMember> Times { get; set; }
    }
}
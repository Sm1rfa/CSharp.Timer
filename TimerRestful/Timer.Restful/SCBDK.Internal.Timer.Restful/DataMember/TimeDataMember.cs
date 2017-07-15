using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timer.Restful.DataMember
{
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
        public string WorkDate { get; set; }

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
        public List<ProjectDataMember> Projects { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        [DataMember]
        public List<UserDataMember> Users { get; set; }
    }
}
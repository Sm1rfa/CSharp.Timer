// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logging.cs" company="Time Register">
//   Logger
// </copyright>
// <summary>
//   Defines the Logging type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

namespace Timer.Context.Models
{
    /// <summary>
    /// The logging.
    /// </summary>
    public class Logging
    {
        /// <summary>
        /// Gets or sets the log id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoggingId { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the logger name.
        /// </summary>
        public string LoggerName { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the machine name.
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        public string StackTrace { get; set; }
    }
}

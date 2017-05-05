// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimerDbEntities.cs" company="Timer Project">
// Timer Project  
// </copyright>
// <summary>
//   Defines the TimerDbEntities type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using Timer.Context.Models;

namespace Timer.Context.Context
{
    /// <summary>
    /// The timer database entities.
    /// </summary>
    public class TimerDbEntities : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerDbEntities"/> class.
        /// </summary>
        public TimerDbEntities()
            : base("name=Timer")
        {
        }

        /// <summary>
        /// Gets or sets the user entity.
        /// </summary>
        public virtual DbSet<User> UserEntity { get; set; }

        /// <summary>
        /// Gets or sets the time entity.
        /// </summary>
        public virtual DbSet<Time> TimeEntity { get; set; }

        /// <summary>
        /// Gets or sets the project entity.
        /// </summary>
        public virtual DbSet<Project> ProjectEntity { get; set; }

        /// <summary>
        /// Gets or sets the department entity.
        /// </summary>
        public virtual DbSet<Department> DepartmentEntity { get; set; }

        /// <summary>
        /// Gets or sets the logging entity.
        /// </summary>
        public virtual DbSet<Logging> LoggingEntity { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

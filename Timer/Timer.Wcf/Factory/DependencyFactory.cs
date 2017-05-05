// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyFactory.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the DependencyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Timer.Context.Context;

namespace Timer.Wcf.Factory
{
    /// <summary>
    /// The dependency factory.
    /// </summary>
    public class DependencyFactory : IDependencyFactory
    {
        /// <summary>
        /// The create timer entities.
        /// </summary>
        /// <returns>
        /// The <see cref="TimerDbEntities"/>.
        /// </returns>
        public TimerDbEntities CreateTimerEntities()
        {
            return new TimerDbEntities();
        }
    }
}
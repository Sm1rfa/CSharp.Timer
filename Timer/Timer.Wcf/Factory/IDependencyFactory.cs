// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDependencyFactory.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the IDependencyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Timer.Context.Context;

namespace Timer.Wcf.Factory
{
    /// <summary>
    /// The DependencyFactory interface.
    /// </summary>
    public interface IDependencyFactory
    {
        /// <summary>
        /// The create timer entities.
        /// </summary>
        /// <returns>
        /// The <see cref="TimerDbEntities"/>.
        /// </returns>
        TimerDbEntities CreateTimerEntities();
    }
}

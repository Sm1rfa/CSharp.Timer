// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITimeRepository.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the ITimeRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Interfaces
{
    /// <summary>
    /// The TimeRepository interface.
    /// </summary>
    public interface ITimeRepository
    {
        /// <summary>
        /// The retrieve times.
        /// </summary>
        /// <returns>
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        List<TimeDataMember> RetrieveTimes();

        /// <summary>
        /// The retrieve time.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        TimeDataMember RetrieveTime(int id);

        /// <summary>
        /// The add time.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool AddTime(TimeDataMember time);

        /// <summary>
        /// The upgrade time.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool UpgradeTime(TimeDataMember time);

        /// <summary>
        /// The remove time.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool RemoveTime(int id);
    }
}
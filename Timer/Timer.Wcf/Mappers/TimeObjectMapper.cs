// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeObjectMapper.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the TimeObjectMapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Timer.Context.Models;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Mappers
{
    /// <summary>
    /// The time object mapper.
    /// </summary>
    public class TimeObjectMapper
    {
        /// <summary>
        /// The map project to user object.
        /// </summary>
        /// <param name="timeEntity">
        /// The time entity.
        /// </param>
        /// <returns>
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        public List<TimeDataMember> MapTimeListToObject(ICollection<Time> timeEntity)
        {
            var userTimesList = timeEntity.Select(item => new TimeDataMember
            {
                TimeId = item.TimeId,
                WorkDate = item.WorkDate,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                Break = item.Break,
                Note = item.Note
            }).ToList();

            return userTimesList;
        }

        /// <summary>
        /// The map time to object.
        /// </summary>
        /// <param name="timeEntity">
        /// The time entity.
        /// </param>
        /// <returns>
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        public TimeDataMember MapTimeToObject(Time timeEntity)
        {
            return new TimeDataMember
            {
                TimeId = timeEntity.TimeId,
                WorkDate = timeEntity.WorkDate,
                StartTime = timeEntity.StartTime,
                EndTime = timeEntity.EndTime,
                Break = timeEntity.Break,
                Projects = timeEntity.Projects.ToList(),
                Note = timeEntity.Note,
                Users = timeEntity.Users.ToList()
            };
        }
    }
}
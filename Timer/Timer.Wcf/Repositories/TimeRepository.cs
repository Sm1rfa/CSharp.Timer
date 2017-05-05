// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeRepository.cs" company="Timer Project">
//   Timer Project
// </copyright>
// <summary>
//   Defines the TimeRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLog;
using Timer.Context.Models;
using Timer.Wcf.DataMembers;
using Timer.Wcf.Factory;
using Timer.Wcf.Interfaces;
using Timer.Wcf.Mappers;

namespace Timer.Wcf.Repositories
{
    /// <summary>
    /// The time repository.
    /// </summary>
    public class TimeRepository : ITimeRepository
    {
        /// <summary>
        /// The dependency factory.
        /// </summary>
        private readonly IDependencyFactory dependencyFactory;

        /// <summary>
        /// The time map.
        /// </summary>
        private TimeObjectMapper timeMap;

        /// <summary>
        /// The logger.
        /// </summary>
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeRepository"/> class.
        /// </summary>
        /// <param name="dependencyFactory">
        /// The dependency factory.
        /// </param>
        public TimeRepository(IDependencyFactory dependencyFactory)
        {
            this.dependencyFactory = dependencyFactory;
        }

        /// <summary>
        /// The retrieve times.
        /// </summary>
        /// <returns>
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong
        /// </exception>
        public List<TimeDataMember> RetrieveTimes()
        {
            var timeList = new List<TimeDataMember>();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var timeEntitiy = (from t in context.TimeEntity select t).ToList();
                    timeList.AddRange(timeEntitiy.Select(t => new TimeDataMember
                    {
                        TimeId = t.TimeId,
                        WorkDate = t.WorkDate,
                        StartTime = t.StartTime,
                        EndTime = t.EndTime,
                        Break = t.Break,
                        Projects = t.Projects.ToList(),
                        Note = t.Note,
                        Users = t.Users.ToList()
                    }));
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return timeList;
        }

        /// <summary>
        /// The retrieve time.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public TimeDataMember RetrieveTime(int id)
        {
            var timeMapped = new TimeDataMember();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var timeEntity = (from t in context.TimeEntity where t.TimeId == id select t).FirstOrDefault();
                    if (timeEntity != null)
                    {
                        this.timeMap = new TimeObjectMapper();
                        timeMapped = this.timeMap.MapTimeToObject(timeEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return timeMapped;
        }

        /// <summary>
        /// The add time.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception where it is needed
        /// </exception>
        public bool AddTime(TimeDataMember time)
        {
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var userList = time.Users.Select(item => new User { UserId = item.UserId }).Select(user => context.UserEntity.Attach(user)).ToList();

                    var projectList = time.Projects.Select(item => new Project { ProjectId = item.ProjectId }).Select(project => context.ProjectEntity.Attach(project)).ToList();

                    var timeData = new Time
                    {
                        TimeId = time.TimeId,
                        WorkDate = time.WorkDate,
                        StartTime = time.StartTime,
                        EndTime = time.EndTime,
                        Break = time.Break,
                        Note = time.Note,
                        Users = userList,
                        Projects = projectList
                    };

                    // var context = this.dependencyFactory.CreateTimerEntities();

                    context.TimeEntity.Add(timeData);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return true;
        }

        /// <summary>
        /// The upgrade time.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public bool UpgradeTime(TimeDataMember time)
        {
            try
            {
                var timeId = time.TimeId;
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var timeEntity = (from t in context.TimeEntity where t.TimeId == timeId select t).FirstOrDefault();
                    if (timeEntity != null)
                    {
                        timeEntity.WorkDate = time.WorkDate;
                        timeEntity.StartTime = time.StartTime;
                        timeEntity.EndTime = time.EndTime;
                        //timeEntity.Break = time.Break;
                        //timeEntity.Note = time.Note;
                        //timeEntity.Users = time.Users.ToList();
                        //timeEntity.Projects = time.Projects.ToList();

                        context.Entry(timeEntity).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return true;
        }

        /// <summary>
        /// The remove time.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws new exception if something went wrong.
        /// </exception>
        public bool RemoveTime(int id)
        {
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var timeEntity = (from t in context.TimeEntity where t.TimeId == id select t).FirstOrDefault();
                    if (timeEntity == null)
                    {
                        return false;
                    }

                    context.TimeEntity.Remove(timeEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return true;
        }
    }
}
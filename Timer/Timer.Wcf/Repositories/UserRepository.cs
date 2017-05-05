// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the UserRepository type.
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
    /// The user repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The dependency factory.
        /// </summary>
        private readonly IDependencyFactory dependencyFactory;

        /// <summary>
        /// The mapper.
        /// </summary>
        private UserObjectMapper mapper;

        /// <summary>
        /// The time mapper.
        /// </summary>
        private TimeObjectMapper timeMapper;

        /// <summary>
        /// The project mapper.
        /// </summary>
        private ProjectObjectMapper projectMapper;

        /// <summary>
        /// The department mapper.
        /// </summary>
        private DepartmentObjectMapper departmentMapper;

        /// <summary>
        /// The logger.
        /// </summary>
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        public UserRepository(IDependencyFactory factory)
        {
            this.dependencyFactory = factory;
        }

        /// <summary>
        /// The retrieve users.
        /// </summary>
        /// <returns>
        /// The <see cref="UserDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public List<UserDataMember> RetrieveUsers()
        {
            this.mapper = new UserObjectMapper();
            this.timeMapper = new TimeObjectMapper();
            this.projectMapper = new ProjectObjectMapper();
            this.departmentMapper = new DepartmentObjectMapper();
            var usersList = new List<UserDataMember>();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var userEntity = (from u in context.UserEntity select u).ToList();
                    usersList.AddRange(userEntity.Select(u => new UserDataMember
                    {
                        UserId = u.UserId,
                        Firstname = u.Firstname,
                        Lastname = u.Lastname,
                        Email = u.Email,
                        Password = u.Password,
                        Account = u.Account,
                        IsAdmin = u.IsAdmin,
                        Projects = u.Projects.ToList(),
                        Department = u.Department,
                        Times = u.Times.ToList(),
                        FullName = u.Firstname + " " + u.Lastname
                    }));
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return usersList;
        }

        /// <summary>
        /// The retrieve user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="UserDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public UserDataMember RetrieveUser(int id)
        {
            var userMapped = new UserDataMember();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var userEntity = (from u in context.UserEntity where u.UserId == id select u).FirstOrDefault();
                    if (userEntity != null)
                    {
                        this.mapper = new UserObjectMapper();
                        userMapped = this.mapper.MapUserToObject(userEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return userMapped;
        }

        /// <summary>
        /// The add user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddUser(UserDataMember user)
        {
            try
            {
                var context = this.dependencyFactory.CreateTimerEntities();

                var projectList = user.Projects.Select(item => new Project { ProjectId = item.ProjectId }).Select(project => context.ProjectEntity.Attach(project)).ToList();

                var department = context.DepartmentEntity.Attach(user.Department);

                var userData = new User
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    Password = user.Password,
                    Account = user.Account,
                    IsAdmin = user.IsAdmin,
                    Department = department,
                    Projects = projectList
                };
                
                context.UserEntity.Add(userData);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return true;
        }

        /// <summary>
        /// The edit user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <exception cref="Exception">
        /// throw an exception if something went wrong.
        /// </exception>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool EditUser(UserDataMember user)
        {
            try
            {
                var userId = user.UserId;
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var userEntity = (from u in context.UserEntity where u.UserId == userId select u).FirstOrDefault();
                    if (userEntity != null)
                    {
                        userEntity.Firstname = user.Firstname;
                        userEntity.Lastname = user.Lastname;
                        userEntity.Email = user.Email;
                        userEntity.Account = user.Account;
                        userEntity.Password = user.Password;
                        userEntity.IsAdmin = user.IsAdmin;
                        user.Department = user.Department;
                        user.Projects = user.Projects.ToList();

                        context.Entry(userEntity).State = EntityState.Modified;
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
        /// The remove user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="Exception">
        /// throw an exception if something went wrong.
        /// </exception>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RemoveUser(int id)
        {
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var userEntity = (from u in context.UserEntity where u.UserId == id select u).FirstOrDefault();
                    if (userEntity == null)
                    {
                        return false;
                    }

                    context.UserEntity.Remove(userEntity);
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
        /// The get info.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="fromDate">
        /// The from date.
        /// </param>
        /// <param name="toDate">
        /// The to date.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public List<Time> GetInfo(int userId, DateTime fromDate, DateTime toDate)
        {
            var timeList = new List<Time>();

            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var entities = (from t in context.TimeEntity
                        where t.Users.Any(u => u.UserId == userId)
                        && t.WorkDate >= fromDate && t.WorkDate <= toDate
                        select t).ToList();

                   timeList.AddRange(entities);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return timeList;
        }
    }
}
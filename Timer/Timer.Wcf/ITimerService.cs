// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITimerService.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the ITimerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf
{
    /// <summary>
    /// The TimerService interface.
    /// </summary>
    [ServiceContract]
    public interface ITimerService
    {
        /// <summary>
        /// The get async users.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<List<UserDataMember>> GetAsyncUsers();

        /// <summary>
        /// The get async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="UserDataMember"/>.
        /// </returns>
        [OperationContract]
        Task<UserDataMember> GetAsyncUser(int id);

        /// <summary>
        /// The create async user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> CreateAsyncUser(UserDataMember user);

        /// <summary>
        /// The update async user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> UpdateAsyncUser(UserDataMember user);

        /// <summary>
        /// The delete async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> DeleteAsyncUser(int id);

        /// <summary>
        /// The get async users.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<List<TimeDataMember>> GetAsyncTimes();

        /// <summary>
        /// The get async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        [OperationContract]
        Task<TimeDataMember> GetAsyncTime(int id);

        /// <summary>
        /// The create async user.
        /// </summary>
        /// <param name="time">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> CreateAsyncTime(TimeDataMember time);

        /// <summary>
        /// The update async user.
        /// </summary>
        /// <param name="time">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> UpdateAsyncTime(TimeDataMember time);

        /// <summary>
        /// The delete async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> DeleteAsyncTime(int id);

        /// <summary>
        /// The get async users.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<List<ProjectDataMember>> GetAsyncProjects();

        /// <summary>
        /// The get async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        [OperationContract]
        Task<ProjectDataMember> GetAsyncProject(int id);

        /// <summary>
        /// The create async user.
        /// </summary>
        /// <param name="project">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> CreateAsyncProject(ProjectDataMember project);

        /// <summary>
        /// The update async user.
        /// </summary>
        /// <param name="project">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> UpdateAsyncProject(ProjectDataMember project);

        /// <summary>
        /// The delete async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> DeleteAsyncProject(int id);

        /// <summary>
        /// The get async users.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<List<DepartmentDataMember>> GetAsyncDepartments();

        /// <summary>
        /// The get async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        [OperationContract]
        Task<DepartmentDataMember> GetAsyncDepartment(int id);

        /// <summary>
        /// The create async user.
        /// </summary>
        /// <param name="department">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> CreateAsyncDepartment(DepartmentDataMember department);

        /// <summary>
        /// The update async user.
        /// </summary>
        /// <param name="department">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> UpdateAsyncDepartment(DepartmentDataMember department);

        /// <summary>
        /// The delete async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OperationContract]
        Task<bool> DeleteAsyncDepartment(int id);

        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [OperationContract]
        bool SendMessage(string from, string to, string subject, string message);

        /// <summary>
        /// The retrieve time for user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        [OperationContract]
        List<TimeDataMember> RetrieveTimeForUser(int userId, DateTime from, DateTime to);
    }
}

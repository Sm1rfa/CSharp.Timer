// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimerService.svc.cs" company="Timer Project">
//   Timer Project
// </copyright>
// <summary>
//   Defines the TimerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timer.Wcf.DataMembers;
using Timer.Wcf.Factory;
using Timer.Wcf.Interfaces;
using Timer.Wcf.Repositories;
using Timer.Wcf.Utils;

namespace Timer.Wcf
{
    /// <summary>
    /// The timer service.
    /// </summary>
    public class TimerService : ITimerService
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// The project repository.
        /// </summary>
        private IProjectRepository projectRepository;

        /// <summary>
        /// The department repository.
        /// </summary>
        private IDepartmentRepository departmentRepository;

        /// <summary>
        /// The time repository.
        /// </summary>
        private ITimeRepository timeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerService"/> class.
        /// </summary>
        /// <param name="urepo">
        /// The user repository.
        /// </param>
        /// <param name="prepo">
        /// The project repository.
        /// </param>
        /// <param name="drepo">
        /// The department repository.
        /// </param>
        /// <param name="trepo">
        /// The time repository.
        /// </param>
        public TimerService(IUserRepository urepo, IProjectRepository prepo, IDepartmentRepository drepo, ITimeRepository trepo)
        {
            this.userRepository = urepo;
            this.projectRepository = prepo;
            this.departmentRepository = drepo;
            this.timeRepository = trepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerService"/> class.
        /// </summary>
        public TimerService()
        {
            this.userRepository = new UserRepository(new DependencyFactory());
            this.timeRepository = new TimeRepository(new DependencyFactory());
            this.projectRepository = new ProjectRepository(new DependencyFactory());
            this.departmentRepository = new DepartmentRepository(new DependencyFactory());
        }

        /// <summary>
        /// The get async users.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<UserDataMember>> GetAsyncUsers()
        {
            return await Task.Factory.StartNew(() => this.userRepository.RetrieveUsers());
        }

        /// <summary>
        /// The get async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<UserDataMember> GetAsyncUser(int id)
        {
            return await Task.Factory.StartNew(() => this.userRepository.RetrieveUser(id));
        }

        /// <summary>
        /// The create async user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> CreateAsyncUser(UserDataMember user)
        {
            return await Task.Factory.StartNew(() => this.userRepository.AddUser(user));
        }

        /// <summary>
        /// The update async user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> UpdateAsyncUser(UserDataMember user)
        {
            return await Task.Factory.StartNew(() => this.userRepository.EditUser(user));
        }

        /// <summary>
        /// The delete async user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> DeleteAsyncUser(int id)
        {
            return await Task.Factory.StartNew(() => this.userRepository.RemoveUser(id));
        }

        /// <summary>
        /// The get async times.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<TimeDataMember>> GetAsyncTimes()
        {
            return await Task.Factory.StartNew(() => this.timeRepository.RetrieveTimes());
        }

        /// <summary>
        /// The get async time.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TimeDataMember> GetAsyncTime(int id)
        {
            return await Task.Factory.StartNew(() => this.timeRepository.RetrieveTime(id));
        }

        /// <summary>
        /// The create async time.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> CreateAsyncTime(TimeDataMember time)
        {
            return await Task.Factory.StartNew(() => this.timeRepository.AddTime(time));
        }

        /// <summary>
        /// The update async time.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> UpdateAsyncTime(TimeDataMember time)
        {
            return await Task.Factory.StartNew(() => this.timeRepository.UpgradeTime(time));
        }

        /// <summary>
        /// The delete async time.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> DeleteAsyncTime(int id)
        {
            return await Task.Factory.StartNew(() => this.timeRepository.RemoveTime(id));
        }

        /// <summary>
        /// The get async projects.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<ProjectDataMember>> GetAsyncProjects()
        {
            return await Task.Factory.StartNew(() => this.projectRepository.RetrieveProjects());
        }

        /// <summary>
        /// The get async project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ProjectDataMember> GetAsyncProject(int id)
        {
            return await Task.Factory.StartNew(() => this.projectRepository.RetrieveProject(id));
        }

        /// <summary>
        /// The create async project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> CreateAsyncProject(ProjectDataMember project)
        {
            return await Task.Factory.StartNew(() => this.projectRepository.AddProject(project));
        }

        /// <summary>
        /// The update async project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> UpdateAsyncProject(ProjectDataMember project)
        {
            return await Task.Factory.StartNew(() => this.projectRepository.UpgradeProject(project));
        }

        /// <summary>
        /// The delete async project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> DeleteAsyncProject(int id)
        {
            return await Task.Factory.StartNew(() => this.projectRepository.RemoveProject(id));
        }

        /// <summary>
        /// The get async departments.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<DepartmentDataMember>> GetAsyncDepartments()
        {
            return await Task.Factory.StartNew(() => this.departmentRepository.RetrieveDepartments());
        }

        /// <summary>
        /// The get async department.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<DepartmentDataMember> GetAsyncDepartment(int id)
        {
            return await Task.Factory.StartNew(() => this.departmentRepository.RetrieveDepartment(id));
        }

        /// <summary>
        /// The create async department.
        /// </summary>
        /// <param name="department">
        /// The department.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> CreateAsyncDepartment(DepartmentDataMember department)
        {
            return await Task.Factory.StartNew(() => this.departmentRepository.AddDepartment(department));
        }

        /// <summary>
        /// The update async department.
        /// </summary>
        /// <param name="department">
        /// The department.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> UpdateAsyncDepartment(DepartmentDataMember department)
        {
            return await Task.Factory.StartNew(() => this.departmentRepository.UpgradeDepartment(department));
        }

        /// <summary>
        /// The delete async department.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> DeleteAsyncDepartment(int id)
        {
            return await Task.Factory.StartNew(() => this.departmentRepository.RemoveDepartment(id));
        }

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
        public bool SendMessage(string from, string to, string subject, string message)
        {
            try
            {
                var msg = new MessageHelper();
                msg.SendMail(from, to, subject, message);
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

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
        public List<TimeDataMember> RetrieveTimeForUser(int userId, DateTime from, DateTime to)
        {
            var list = new List<TimeDataMember>();

            try
            {
                list.AddRange(this.userRepository.GetInfo(userId, @from, to).Select(item => new TimeDataMember
                {
                    TimeId = item.TimeId,
                    WorkDate = item.WorkDate,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Note = item.Note,
                    Break = item.Break,
                    Users = item.Users.ToList(),
                    Projects = item.Projects.ToList()
                }));
            }
            catch (Exception)
            {
                return null;
            }

            return list;
        }
    }
}

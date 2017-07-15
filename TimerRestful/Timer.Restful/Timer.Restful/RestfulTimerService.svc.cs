
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Timer.Restful.Service_References.TimerService;

namespace Timer.Restful
{
    using UserDataMember = DataMember.UserDataMember;

    /// <summary>
    /// The restful timer service.
    /// </summary>
    public class RestfulTimerService : IRestfulTimerService
    {
        /// <summary>
        /// The get all users.
        /// </summary>
        /// <returns>
        /// The <see cref="UserDataMember"/>.
        /// </returns>
        public List<UserDataMember> GetAllUsers()
        {
            try
            {
                var client = new TimerServiceClient();

                return client.GetAsyncUsers().Select(item => new UserDataMember
                {
                    Account = item.Account,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Password = item.Password,
                    Email = item.Email,
                    FullName = item.FullName,
                    IsAdmin = item.IsAdmin,
                    UserId = item.UserId,
                    Department = item.Department,
                    Projects = item.Projects.ToList(),
                    Times = item.Times.ToList()
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// The get all departments.
        /// </summary>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        public List<DepartmentDataMember> GetAllDepartments()
        {
            try
            {
                var client = new TimerServiceClient();

                return client.GetAsyncDepartments().Select(item => new DepartmentDataMember
                {
                    DepartmentId = item.DepartmentId,
                    DepartmentName = item.DepartmentName,
                    DepartmentEmail = item.DepartmentEmail,
                    Users = item.Users
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// The get all projects.
        /// </summary>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        public List<ProjectDataMember> GetAllProjects()
        {
            try
            {
                var client = new TimerServiceClient();

                return client.GetAsyncProjects().Select(item => new ProjectDataMember
                {
                    ProjectId = item.ProjectId,
                    ProjectName = item.ProjectName,
                    ProjectDescription = item.ProjectDescription,
                    Users = item.Users,
                    Times = item.Times
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// The register time.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="projId">
        /// The project id.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="startTime">
        /// The start time.
        /// </param>
        /// <param name="endTime">
        /// The end time.
        /// </param>
        /// <param name="breakTime">
        /// The break time.
        /// </param>
        /// <param name="comments">
        /// The comments.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RegisterTime(string userId, string projId, string date, string startTime, string endTime, string breakTime, string comments)
        {
            var uId = int.Parse(userId);
            var pId = int.Parse(projId);
            var br = int.Parse(breakTime);
            var d = DateTime.ParseExact(date, @"dd-MM-yyyy", CultureInfo.InvariantCulture);

            try
            {
                var client = new TimerServiceClient();

                var proj = client.GetAsyncProject(pId);
                Project[] p = new Project[]
                {
                    new Project
                    {
                        ProjectId = proj.ProjectId,
                        ProjectName = proj.ProjectName,
                        ProjectDescription = proj.ProjectDescription,
                        Times = proj.Times,
                        Users = proj.Users
                    }
                };

                var user = client.GetAsyncUser(uId);
                User[] u = new User[]
                {
                    new User
                    {
                        UserId = user.UserId,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Password = user.Password,
                        Account = user.Account,
                        Email = user.Email,
                        IsAdmin = user.IsAdmin,
                        Department = user.Department,
                        Projects = user.Projects,
                        Times = user.Times
                    } 
                };

                var data = new TimeDataMember
                {
                    WorkDate = d,
                    StartTime = startTime,
                    EndTime = endTime,
                    Break = br,
                    Note = comments,
                    Users = u,
                    Projects = p
                };

                client.CreateAsyncTime(data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// The get user time.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="dateFrom">
        /// The date From.
        /// </param>
        /// <param name="dateTo">
        /// The date To.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public List<DataMember.TimeDataMember> GetUserTime(string userId, string dateFrom, string dateTo)
        {
            var outputFormat = "dd-MM-yyyy";

            var date1 = DateTime.ParseExact(dateFrom, outputFormat, CultureInfo.InvariantCulture);
            var date2 = DateTime.ParseExact(dateTo, outputFormat, CultureInfo.InvariantCulture);
            var id = int.Parse(userId);

            try
            {
                var client = new TimerServiceClient();
                var result = client.RetrieveTimeForUser(id, date1, date2).Select(item => new TimeDataMember
                {
                    WorkDate = item.WorkDate,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Break = item.Break,
                    Note = item.Note,
                    Projects = item.Projects
                }).ToList();

                var requestedTime = new List<DataMember.TimeDataMember>();
                requestedTime.AddRange(result.Select(x => new DataMember.TimeDataMember
                {
                    WorkDate = x.WorkDate.ToShortDateString(),
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Break = x.Break,
                    Note = x.Note,
                    Projects = new List<DataMember.ProjectDataMember>()
                }));

                return requestedTime;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + e.InnerException);
            }
        }

        /// <summary>
        /// The send mail.
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
        public bool SendMail(string @from, string to, string subject, string message)
        {
            try
            {
                var client = new TimerServiceClient();
                client.SendMessage(@from, to, subject, message);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// The add user.
        /// </summary>
        /// <param name="fname">
        /// The first name.
        /// </param>
        /// <param name="lname">
        /// The last name.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <param name="pass">
        /// The password.
        /// </param>
        /// <param name="mail">
        /// The email.
        /// </param>
        /// <param name="isAdmin">
        /// The is admin.
        /// </param>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <param name="deptId">
        /// The department id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddUser(string fname, string lname, string account, string pass, string mail, string isAdmin, string projectId, string deptId)
        {
            var pId = int.Parse(projectId);
            var dId = int.Parse(deptId);
            var admin = bool.Parse(isAdmin);

            var data = new Service_References.TimerService.UserDataMember
            {
                Firstname = fname,
                Lastname = lname,
                Account = account,
                Password = pass,
                Email = mail,
                IsAdmin = admin,
                Projects = new[] { new Project { ProjectId = pId } },
                Department = new Department { DepartmentId = dId }
            };

            try
            {
                var client = new TimerServiceClient();
                client.CreateAsyncUser(data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// The add department.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="mail">
        /// The mail.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddDepartment(string name, string mail)
        {
            var dept = new DepartmentDataMember
            {
                DepartmentName = name,
                DepartmentEmail = mail
            };

            try
            {
                var client = new TimerServiceClient();
                client.CreateAsyncDepartment(dept);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// The add project.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddProject(string name, string description)
        {
            var proj = new ProjectDataMember
            {
                ProjectName = name,
                ProjectDescription = description
            };

            try
            {
                var client = new TimerServiceClient();
                client.CreateAsyncProject(proj);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}


using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Timer.Restful.Service_References.TimerService;

namespace Timer.Restful
{
    using UserDataMember = DataMember.UserDataMember;

    /// <summary>
    /// The RestfulTimerService interface.
    /// </summary>
    [ServiceContract]
    public interface IRestfulTimerService
    {
        /// <summary>
        /// The get all users.
        /// </summary>
        /// <returns>
        /// The <see cref="UserDataMember"/>.
        /// </returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "/GetAllUsers/",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<UserDataMember> GetAllUsers();

        /// <summary>
        /// The get all departments.
        /// </summary>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "/GetAllDepartments/",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<DepartmentDataMember> GetAllDepartments();

        /// <summary>
        /// The get all projects.
        /// </summary>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "/GetAllProjects/",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<ProjectDataMember> GetAllProjects();

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
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/RegisterTime/{userId}/{projId}/{date}/{startTime}/{endTime}/{breakTime}/{comments}")]
        bool RegisterTime(string userId, string projId, string date, string startTime, string endTime, string breakTime, string comments);

        /// <summary>
        /// The get user time.
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
        /// The <see cref="TimeDataMember"/>.
        /// </returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "/GetUserTime/{userId}/{dateFrom}/{dateTo}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<DataMember.TimeDataMember> GetUserTime(string userId, string dateFrom, string dateTo);

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
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/SendMail/{from}/{to}/{subject}/{message}")]
        bool SendMail(string from, string to, string subject, string message);

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
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddUser/{fname}/{lname}/{account}/{pass}/{mail}/{isAdmin}")]
        bool AddUser(string fname, string lname, string account, string pass, string mail, string isAdmin, string projectId, string deptId);

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
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddDepartment/{name}/{mail}")]
        bool AddDepartment(string name, string mail);

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
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddProject/{name}/{description}")]
        bool AddProject(string name, string description);
    }
}

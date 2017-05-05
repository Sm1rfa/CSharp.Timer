// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectMap.cs" company="Time Register Client">
//  Time Register Client 
// </copyright>
// <summary>
//   The object map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TimerControlPanel.Connected_Services.TimerService;

namespace TimerControlPanel.Mappers
{

    /// <summary>
    /// The object map.
    /// </summary>
    public class ObjectMap
    {
        /// <summary>
        /// The map user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User MapUser(int id)
        {
            var client = new TimerServiceClient();
            var user = client.GetAsyncUser(id);

            return new User
            {
                UserId = user.UserId,
                Account = user.Account,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin,
                Department = user.Department,
                Projects = user.Projects
            };
        }

        /// <summary>
        /// The map project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Project"/>.
        /// </returns>
        public Project MapProject(int id)
        {
            var client = new TimerServiceClient();
            var proj = client.GetAsyncProject(id);

            return new Project
            {
                ProjectId = proj.ProjectId,
                ProjectName = proj.ProjectName,
                ProjectDescription = proj.ProjectDescription,
            };
        }
    }
}

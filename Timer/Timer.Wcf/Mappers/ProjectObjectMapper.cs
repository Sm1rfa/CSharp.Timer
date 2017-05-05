// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectObjectMapper.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the ProjectObjectMapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Timer.Context.Models;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Mappers
{
    /// <summary>
    /// The project object mapper.
    /// </summary>
    public class ProjectObjectMapper
    {
        /// <summary>
        /// The map project to user object.
        /// </summary>
        /// <param name="projectEntity">
        /// The project entity.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        public List<ProjectDataMember> MapProjectListToObject(ICollection<Project> projectEntity)
        {
            var userProjectList = projectEntity.Select(item => new ProjectDataMember
            {
                ProjectId = item.ProjectId,
                ProjectName = item.ProjectName,
                ProjectDescription = item.ProjectDescription
            }).ToList();

            return userProjectList;
        }

        /// <summary>
        /// The map project to object.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        public ProjectDataMember MapProjectToObject(Project project)
        {
            return new ProjectDataMember
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                Times = project.Times.ToList(),
                Users = project.Users.ToList()
            };
        }
    }
}
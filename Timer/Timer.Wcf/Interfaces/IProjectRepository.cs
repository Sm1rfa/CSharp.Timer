// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectRepository.cs" company="DepartmentDataMember">
//  DepartmentDataMember 
// </copyright>
// <summary>
//   Defines the IProjectRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Interfaces
{
    /// <summary>
    /// The ProjectRepository interface.
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// The retrieve projects.
        /// </summary>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        List<ProjectDataMember> RetrieveProjects();

        /// <summary>
        /// The retrieve project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        ProjectDataMember RetrieveProject(int id);

        /// <summary>
        /// The add project.
        /// </summary>
        /// <param name="proj">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool AddProject(ProjectDataMember proj);

        /// <summary>
        /// The upgrade project.
        /// </summary>
        /// <param name="proj">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool UpgradeProject(ProjectDataMember proj);

        /// <summary>
        /// The remove project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool RemoveProject(int id);
    }
}
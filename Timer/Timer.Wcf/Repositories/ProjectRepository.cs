// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectRepository.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the ProjectRepository type.
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
    /// The project repository.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        /// <summary>
        /// The dependency factory.
        /// </summary>
        private readonly IDependencyFactory dependencyFactory;

        /// <summary>
        /// The project mapper.
        /// </summary>
        private ProjectObjectMapper projectMapper;

        /// <summary>
        /// The logger.
        /// </summary>
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
        /// </summary>
        /// <param name="dependencyFactory">
        /// The dependency factory.
        /// </param>
        public ProjectRepository(IDependencyFactory dependencyFactory)
        {
            this.dependencyFactory = dependencyFactory;
        }

        /// <summary>
        /// The retrieve projects.
        /// </summary>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public List<ProjectDataMember> RetrieveProjects()
        {
            var projectList = new List<ProjectDataMember>();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var projectEntity = (from p in context.ProjectEntity select p).ToList();
                    projectList.AddRange(projectEntity.Select(p => new ProjectDataMember
                    {
                        ProjectId = p.ProjectId,
                        ProjectName = p.ProjectName,
                        ProjectDescription = p.ProjectDescription,
                        Times = p.Times.ToList(),
                        Users = p.Users.ToList()
                    }));
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in project repository {ex}");
            }

            return projectList;
        }

        /// <summary>
        /// The retrieve project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public ProjectDataMember RetrieveProject(int id)
        {
            var projectMapped = new ProjectDataMember();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var projectEntity = (from p in context.ProjectEntity where p.ProjectId == id select p).FirstOrDefault();
                    if (projectEntity != null)
                    {
                        this.projectMapper = new ProjectObjectMapper();
                        projectMapped = this.projectMapper.MapProjectToObject(projectEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return projectMapped;
        }

        /// <summary>
        /// The add project.
        /// </summary>
        /// <param name="proj">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public bool AddProject(ProjectDataMember proj)
        {
            try
            {
                var projectData = new Project
                {
                    ProjectName = proj.ProjectName,
                    ProjectDescription = proj.ProjectDescription
                };

                var context = this.dependencyFactory.CreateTimerEntities();

                context.ProjectEntity.Add(projectData);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return true;
        }

        /// <summary>
        /// The upgrade project.
        /// </summary>
        /// <param name="proj">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public bool UpgradeProject(ProjectDataMember proj)
        {
            try
            {
                var projectId = proj.ProjectId;
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var projectEntity = (from p in context.ProjectEntity where p.ProjectId == projectId select p).FirstOrDefault();
                    if (projectEntity != null)
                    {
                        projectEntity.ProjectName = proj.ProjectName;
                        projectEntity.ProjectDescription = proj.ProjectDescription;

                        context.Entry(projectEntity).State = EntityState.Modified;
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
        /// The remove project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public bool RemoveProject(int id)
        {
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var projectEntity = (from p in context.ProjectEntity where p.ProjectId == id select p).FirstOrDefault();
                    if (projectEntity == null)
                    {
                        return false;
                    }

                    context.ProjectEntity.Remove(projectEntity);
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
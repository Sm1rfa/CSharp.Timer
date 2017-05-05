// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentRepository.cs" company="Timer Project">
//  Timer Project
// </copyright>
// <summary>
//   Defines the DepartmentRepository type.
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
    /// The department repository.
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        /// <summary>
        /// The dependency factory.
        /// </summary>
        private readonly IDependencyFactory dependencyFactory;

        /// <summary>
        /// The department mapper.
        /// </summary>
        private DepartmentObjectMapper departmentMapper;

        /// <summary>
        /// The logger.
        /// </summary>
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepository"/> class.
        /// </summary>
        /// <param name="dependencyFactory">
        /// The dependency factory.
        /// </param>
        public DepartmentRepository(IDependencyFactory dependencyFactory)
        {
            this.dependencyFactory = dependencyFactory;
        }

        /// <summary>
        /// The retrieve departments.
        /// </summary>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public List<DepartmentDataMember> RetrieveDepartments()
        {
            var departmentList = new List<DepartmentDataMember>();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var departmentEntity = (from d in context.DepartmentEntity select d).ToList();
                    departmentList.AddRange(departmentEntity.Select(d => new DepartmentDataMember
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName,
                        DepartmentEmail = d.DepartmentEmail,
                        Users = d.Users.ToList()
                    }));
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                logger.Error($"Error in department repository {ex}");
            }

            return departmentList;
        }

        /// <summary>
        /// The retrieve department.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public DepartmentDataMember RetrieveDepartment(int id)
        {
            var departmentMapped = new DepartmentDataMember();
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var departmentEntity = (from d in context.DepartmentEntity where d.DepartmentId == id select d).FirstOrDefault();
                    if (departmentEntity != null)
                    {
                        this.departmentMapper = new DepartmentObjectMapper();
                        departmentMapped = this.departmentMapper.MapDepartmentToObject(departmentEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return departmentMapped;
        }

        /// <summary>
        /// The add department.
        /// </summary>
        /// <param name="dept">
        /// The dept.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public bool AddDepartment(DepartmentDataMember dept)
        {
            try
            {
                var departmentData = new Department
                {
                    DepartmentName = dept.DepartmentName,
                    DepartmentEmail = dept.DepartmentEmail
                };

                var context = this.dependencyFactory.CreateTimerEntities();

                context.DepartmentEntity.Add(departmentData);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error($"Error in department repository {ex}");
            }

            return true;
        }

        /// <summary>
        /// The upgrade department.
        /// </summary>
        /// <param name="dept">
        /// The dept.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws an exception if something went wrong.
        /// </exception>
        public bool UpgradeDepartment(DepartmentDataMember dept)
        {
            try
            {
                var departmentId = dept.DepartmentId;
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var departmentEntity = (from d in context.DepartmentEntity where d.DepartmentId == departmentId select d).FirstOrDefault();
                    if (departmentEntity != null)
                    {
                        departmentEntity.DepartmentName = dept.DepartmentName;
                        departmentEntity.DepartmentEmail = dept.DepartmentEmail;

                        context.Entry(departmentEntity).State = EntityState.Modified;
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
        /// The remove department.
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
        public bool RemoveDepartment(int id)
        {
            try
            {
                using (var context = this.dependencyFactory.CreateTimerEntities())
                {
                    var departmentEntity = (from d in context.DepartmentEntity where d.DepartmentId == id select d).FirstOrDefault();
                    if (departmentEntity == null)
                    {
                        return false;
                    }

                    context.DepartmentEntity.Remove(departmentEntity);
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
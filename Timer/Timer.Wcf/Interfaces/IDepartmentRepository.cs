// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDepartmentRepository.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the IDepartmentRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Interfaces
{
    /// <summary>
    /// The DepartmentRepository interface.
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// The retrieve departments.
        /// </summary>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        List<DepartmentDataMember> RetrieveDepartments();

        /// <summary>
        /// The retrieve department.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        DepartmentDataMember RetrieveDepartment(int id);

        /// <summary>
        /// The add department.
        /// </summary>
        /// <param name="dept">
        /// The department.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool AddDepartment(DepartmentDataMember dept);

        /// <summary>
        /// The upgrade department.
        /// </summary>
        /// <param name="dept">
        /// The department.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool UpgradeDepartment(DepartmentDataMember dept);

        /// <summary>
        /// The remove department.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool RemoveDepartment(int id);
    }
}
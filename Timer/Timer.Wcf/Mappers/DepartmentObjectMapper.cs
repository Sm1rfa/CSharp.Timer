// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentObjectMapper.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the DepartmentObjectMapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using Timer.Context.Models;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Mappers
{
    /// <summary>
    /// The department object mapper.
    /// </summary>
    public class DepartmentObjectMapper
    {
        /// <summary>
        /// The map department to user object.
        /// </summary>
        /// <param name="deptEntity">
        /// The department entity.
        /// </param>
        /// <returns>
        /// The <see cref="DepartmentDataMember"/>.
        /// </returns>
        public DepartmentDataMember MapDepartmentToObject(Department deptEntity)
        {
            var userDepartment = new DepartmentDataMember
            {
                DepartmentId = deptEntity.DepartmentId,
                DepartmentName = deptEntity.DepartmentName,
                DepartmentEmail = deptEntity.DepartmentEmail, 
                Users = deptEntity.Users.ToList()
            };

            return userDepartment;
        }
    }
}
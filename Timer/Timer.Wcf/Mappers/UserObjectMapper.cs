// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserObjectMapper.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the UserObjectMapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using Timer.Context.Models;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Mappers
{
    /// <summary>
    /// The user object mapper.
    /// </summary>
    public class UserObjectMapper
    {
        /// <summary>
        /// The map user to object.
        /// </summary>
        /// <param name="userEntity">
        /// The user entity.
        /// </param>
        /// <returns>
        /// The <see cref="UserDataMember"/>.
        /// </returns>
        public UserDataMember MapUserToObject(User userEntity)
        {
            var usermember = new UserDataMember
            {
                UserId = userEntity.UserId,
                Firstname = userEntity.Firstname,
                Lastname = userEntity.Lastname,
                Email = userEntity.Email,
                Account = userEntity.Account,
                IsAdmin = userEntity.IsAdmin,
                Password = userEntity.Password,
                Department = userEntity.Department,
                Projects = userEntity.Projects.ToList(),
                FullName = userEntity.Firstname + " " + userEntity.Lastname
            };

            return usermember;
        }
    }
}
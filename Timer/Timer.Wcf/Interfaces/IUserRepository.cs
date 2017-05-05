// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Timer Project">
//   Timer Project
// </copyright>
// <summary>
//   Defines the IUserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Timer.Context.Models;
using Timer.Wcf.DataMembers;

namespace Timer.Wcf.Interfaces
{
    /// <summary>
    /// The UserRepository interface.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// The retrieve users.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<UserDataMember> RetrieveUsers();

        /// <summary>
        /// The retrieve user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="UserDataMember"/>.
        /// </returns>
        UserDataMember RetrieveUser(int id);

        /// <summary>
        /// The add user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool AddUser(UserDataMember user);

        /// <summary>
        /// The edit user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool EditUser(UserDataMember user);

        /// <summary>
        /// The remove user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool RemoveUser(int id);

        /// <summary>
        /// The get info.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="fromDate">
        /// The from date.
        /// </param>
        /// <param name="toDate">
        /// The to date.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<Time> GetInfo(int userId, DateTime fromDate, DateTime toDate);
    }
}
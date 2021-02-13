﻿using System.Linq;
using System.Threading.Tasks;
using CoreLearning.DBLibrary.Entities;
using CoreLearning.DBLibrary.Interfaces.Common;

namespace CoreLearning.DBLibrary.Interfaces
{
    public interface IUserRepository : IEntityRepository<User>
    {
        Task<IQueryable<User>> GetUsersAsync(string nickname, string userId);
        Task<bool> CheckUserIsCreatedAsync(string login, string password);
        Task<User> GetUserByLoginAsync(string login);
    }
}
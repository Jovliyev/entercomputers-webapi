﻿using EnterComputers.DataAcces.Common.Interfaces;
using EnterComputers.DataAcces.ViewModels.Users;
using EnterComputers.Domain.Entities.Users;

namespace EnterComputers.DataAcces.Interfaces.Users
{
    public interface IUserRepository : IRepository<User, UserViewModel>,
        IGetAll<UserViewModel>, ISearchable<UserViewModel>
    {
        public Task<User?> GetByPhoneAsync(string phone);
    }
}
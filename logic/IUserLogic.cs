﻿using models;
using System.Threading.Tasks;

namespace logic
{
    public interface IUserLogic
    {
        Task<User> AddAsync(User user);
        Task<User> CheckUserExistence(User user);
        Task<User> AddChildUser(User user);
        Task<User> UpdateChildUser(User user);
    }
}

﻿using System;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
    public interface IUserService
    {
        Task<User?> GetUserById(int userId);
        Task<User?> Register(RegisterViewModel registerViewModel);

        Task<string> Login(LoginViewModel loginViewModel);

        Task<bool> DeleteUserById(int userId);

        Task<PagingResultViewModel<User>> GetUsers(SearchUserViewModel searchUserViewModel);
    }
}

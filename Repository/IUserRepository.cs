﻿using System;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);

        Task<User?> Create(RegisterViewModel registerViewModel);

        Task<string> Login(LoginViewModel loginViewModel);

        Task<bool> DeleteUserById(int id);

        Task<PagingResultViewModel<User>> GetUsers(SearchUserViewModel searchUserViewModel);
        //Task<string> Login(LoginViewModel loginViewModel);
    }
}
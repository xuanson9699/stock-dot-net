using System;
using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.Repositories;
//using StockAppWebApi.Repository;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserById(int userId)
        {
            User? user = await _userRepository.GetById(userId);
            return user;
        }

        //public async Task<string> Login(LoginViewModel loginViewModel)
        //{
        //    // Thực hiện thêm mới user
        //    return await _userRepository.Login(loginViewModel);
        //}
        public async Task<User?> Register(RegisterViewModel registerViewModel)
        {
            // Kiểm tra xem username hoặc email đã tồn tại trong database chưa
            //Tạo ra đối tượng User từ RegisterViewModel            
            var existingUserByUsername = await _userRepository
                        .GetByUsername(registerViewModel.Username ?? "");

            var existingUserByEmail = await _userRepository
                .GetByEmail(registerViewModel.Email);
            if (existingUserByEmail != null || existingUserByUsername != null)
            {
                throw new ArgumentException("Username Or Email already exists");
            }

            // Thực hiện thêm mới user
            return await _userRepository.Create(registerViewModel);
        }

        public async Task<string?> Login(LoginViewModel loginViewModel)
        {
            return await _userRepository.Login(loginViewModel);
        }
        public async Task<bool> DeleteUserById(int useId)
        {
            return await _userRepository.DeleteUserById(useId);
        }

    }
}
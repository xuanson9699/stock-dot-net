using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using StockAppWebApi.Untils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using StockAppWebApi.Repository;

namespace StockAppWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockAppContext _context;
        private readonly IConfiguration _config;

        public UserRepository(StockAppContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> DeleteUserById(int userId)
        {
            var userToDelete = await _context.Users.FindAsync(userId);
            if (userToDelete == null)
            {
                return false; // User not found
            }
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return true; // User deleted successfully
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            string hashedPassword = HashUntils.HashPassword(registerViewModel.Password);
            var newUser = new User
            {
                Username = registerViewModel.Username ?? "",
                HashedPassword = hashedPassword,
                Email = registerViewModel.Email,
                Phone = registerViewModel.Phone ?? "",
                Fullname = registerViewModel.Fullname ?? "",
                DateOfBirth = registerViewModel.DateOfBirth,
                Country = registerViewModel.Country ?? ""
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<PagingResultViewModel<User>> GetUsers(SearchUserViewModel searchUserViewModel)
        {
            IQueryable<User> query = _context.Users;
            if (!string.IsNullOrEmpty(searchUserViewModel.SearchTerm))
            {
                query = query.Where(u => u.Username.Contains(searchUserViewModel.SearchTerm) || u.Email.Contains(searchUserViewModel.SearchTerm));
            }

            var totalItems = await query.CountAsync();

            // Sắp xếp theo một trường nào đó (ví dụ: theo ID tăng dần).
            query = query.OrderBy(u => u.Id);

            // Phân trang: Skip() và Take().
            query = query.Skip((searchUserViewModel.PageIndex - 1) * searchUserViewModel.PageSize).Take(searchUserViewModel.PageSize);

            // Thực hiện truy vấn và chuyển đổi kết quả thành danh sách.


            var users = await query.ToListAsync();

            var pageNumber = searchUserViewModel.PageIndex;
            var pageSize = searchUserViewModel.PageSize;

            var pagingResult = new PagingResultViewModel<User>(
            users,
            totalItems,
            pageNumber,
            pageSize
        );

            return pagingResult;
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {

            //var existingUserByEmail = await _userRepository.GetByEmail(loginViewModel.Email);

            //if (existingUserByEmail is null)
            //{
            //    throw new ArgumentException("Username does not exists");
            //}
            //string sql = "EXECUTE dbo.CheckLogin @email, @password";
            //IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
            //            new SqlParameter("@email", loginViewModel.Email),
            //            new SqlParameter("@password", loginViewModel.Password))
            //    .ToListAsync();

            //User? user = result.FirstOrDefault();
            string hashedPassword = HashUntils.HashPassword(loginViewModel.Password);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginViewModel.Email && u.HashedPassword == hashedPassword);

            if (user != null)
            {
                //tạo ra jwt string để gửi cho client
                // Nếu xác thực thành công, tạo JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"] ?? "");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        //Đoạn truyền thông tin vào token
                        new Claim("USER_ID", user.Id.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials
                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return jwtToken;
            }
            else
            {
                throw new ArgumentException("Wrong email or password");
            }
        }
    }

}
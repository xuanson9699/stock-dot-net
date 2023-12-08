using System;
using StockAppWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;
using StockAppWebApi.Attributes;

namespace StockAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //https://localhost:port/api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                User? user = await _userService.Register(registerViewModel);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                var jwt = await _userService.Login(loginViewModel);
                return Ok(new { jwt });

            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{userId}")]
        [JwtAuthorize]
        public async Task<IActionResult> DeleteUserById(int userId)
        {
            var result = await _userService.DeleteUserById(userId);

            if (result)
            {
                return Ok(new { Message = "User deleted successfully." });
            }
            else
            {
                return NotFound(new { Message = "User not found." });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] SearchUserViewModel searchUserViewModel)
        {
            try
            {
                var data = await _userService.GetUsers(searchUserViewModel);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
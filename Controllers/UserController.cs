using System;
using StockAppWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

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
                return Ok(jwt);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{userId}")]
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
        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    try
        //    {
        //        string jwtToken = await _userService.Login(loginViewModel);
        //        return Ok(new { jwtToken });
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(new { Message = ex.Message });
        //    }
        //}
    }
}
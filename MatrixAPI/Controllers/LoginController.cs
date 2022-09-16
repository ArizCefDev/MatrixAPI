using BusinessLayer.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MatrixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(UserDTO p)
        {
            _userService.Insert(p);
            return Ok();
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(UserDTO p)
        {
            try
            {
                var values = _userService.Login(p);
                if (values == null)
                {
                    return NotFound();
                }

                Authenticate(values);
                return Ok(p);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }

        //Cookie
        private void Authenticate(UserDTO p)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", p.ID.ToString()),
                new Claim("Music", "techno"),
                new Claim(ClaimTypes.Name, p.UserName),
                new Claim(ClaimTypes.Role, "Admin"),

            };


            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}

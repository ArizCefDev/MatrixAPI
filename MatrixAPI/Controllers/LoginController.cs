using BusinessLayer.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
                return Ok(p);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}

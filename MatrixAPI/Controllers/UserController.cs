using BusinessLayer.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MatrixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult UserGet()
        {
            var values = _userService.GetAll();
            return Ok(values.OrderByDescending(x=>x.ID));
        }

        [HttpGet("{id}")]
        public IActionResult UserGet(int id)
        {
            var values = _userService.GetById(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }

        [HttpPost]
        public IActionResult UserAdd(UserDTO p)
        {
            _userService.Insert(p);
            return Ok();
        }

        [HttpPut]
        public IActionResult UserUpdate(UserDTO p)
        {
            _userService.Update(p);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult UserDelete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }


    }
}

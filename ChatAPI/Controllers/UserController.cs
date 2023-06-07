using System;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userList;

        public UserController(IUserRepository userList)
        {
            _userList = userList;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userList.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userList.GetUserList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            _userList.UpdateUser(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            _userList.PutUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _userList.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                _userList.DeleteUser(user);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}   
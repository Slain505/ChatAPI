using System;
using ChatAPI.Infrastructure.Users;
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
        public IActionResult Update(UserEntity userModel)
        {
            _userList.UpdateUser(userModel);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UserEntity userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _userList.PutUser(userModel);
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
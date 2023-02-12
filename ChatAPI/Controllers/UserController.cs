using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserList _userList;

        public UserController(UserList userList)
        {
            _userList = userList;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var user = _userList.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        //Update instead of Set
        [HttpPost]
        public IActionResult Set(IUsers user)
        {
            _userList.SetUser(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(IUsers user)
        {
            _userList.PutUser(user);
            return Ok();
        }
    }
}   
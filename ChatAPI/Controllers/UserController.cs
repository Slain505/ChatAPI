using System;
using ChatAPI.Infrastructure.Users;
using ChatAPI.Models;
using ChatAPI.Utils;
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

            var userResponse = new UserResponseModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName
            };

            return Ok(userResponse);
        }

        [HttpGet]
        public IActionResult Get(UserRequestModel userRequestModel)
        {
            //rework to UserEntity model use
            var users = _userList.GetUserList();
            
            /*var userResponse = users
            {
                Email = users.Email,
                FirstName = users.FirstName,
                Id = users.Id,
                LastName = users.LastName
            };*/
            
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Update(UserRequestModel userRequestModel)
        {
            var userEntity = _userList.GetUser(userRequestModel.Id);
            userEntity.Email = userRequestModel.Email;
            userEntity.FirstName = userRequestModel.FirstName;
            userEntity.Id = userRequestModel.Id;
            userEntity.LastName = userRequestModel.LastName;
            userEntity.PasswordHash = userRequestModel.Password.ComputeSha256Hash(); 
            
            _userList.UpdateUser(userEntity);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UserRequestModel userRequestModel)
        {
            var userEntity = new UserEntity()
            {
                Email = userRequestModel.Email,
                FirstName = userRequestModel.FirstName,
                Id = userRequestModel.Id,
                LastName = userRequestModel.LastName,
                PasswordHash = userRequestModel.Password.ComputeSha256Hash()
            };
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _userList.PutUser(userEntity);
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
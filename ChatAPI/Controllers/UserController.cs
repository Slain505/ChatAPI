using System;
using System.Collections.Generic;
using System.Linq;
using ChatAPI.Filters;
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
                LastName = user.LastName,
                Username = user.Username,
            };

            return Ok(userResponse);
        }

        [HttpGet]
        [AuthorizationFilter]
        public IActionResult Get()
        {
            var users = _userList.GetUserList();
            var userResponseList = new List<UserResponseModel>();
            // Using foreach instead of LINQ methods
            foreach(var user in users)
            {
                var userResponse = new UserResponseModel()
                { 
                    Email = user.Email, 
                    FirstName = user.FirstName, 
                    Id = user.Id, 
                    LastName = user.LastName,
                    Username = user.Username,
                }; 
                userResponseList.Add(userResponse);
            }
            
            /* Example with LINQ
             var userResponse = users.Select(user => new UserEntity()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName
            }).ToArray();*/
            
            return Ok(userResponseList);
        }

        [HttpPost]
        public IActionResult Update(UserRequestModel userRequestModel)
        {
            var userEntity = _userList.GetUser(userRequestModel.Id);
            userEntity.Email = userRequestModel.Email;
            userEntity.FirstName = userRequestModel.FirstName;
            userEntity.LastName = userRequestModel.LastName;
            userEntity.PasswordHash = userRequestModel.Password.ComputeSha256Hash();
            userEntity.Username = userRequestModel.Username;
            
            _userList.UpdateUser(userEntity);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UserAddModel userAddModel)
        {
            var userEntity = new UserAddModel()
            {
                Email = userAddModel.Email,
                FirstName = userAddModel.FirstName,
                LastName = userAddModel.LastName,
                PasswordHash = userAddModel.Password.ComputeSha256Hash(),
                Username = userAddModel.Username,
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

        [HttpDelete]
        public IActionResult DeleteAll(UserRequestModel userRequestModel)
        {
            try
            {
                var users = _userList.GetUserList();
                if (users == null)
                {
                    return NotFound();
                }

                _userList.DeleteAllUsers(new UserEntity());
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}   
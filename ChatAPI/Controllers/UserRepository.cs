using System.Collections.Generic;
using ChatAPI.Infrastructure.Users;
using ChatAPI.Services;

namespace ChatAPI
{
   public class UserRepository : IUserRepository
   {
      private List<UserEntity> _users = new List<UserEntity>();
      private IdGenerator idGenerator;

      public UserRepository()
      {
         _users = new List<UserEntity>();
      }
      
      public UserEntity GetUser(int id)
      {
         return _users.Find(u => u.Id == id);
      }

      public IEnumerable<UserEntity> GetUserList()
      {
         return _users;
      }

      public void UpdateUser(UserEntity userModel)
      {
         var existingUser = _users.Find(u => u.Id == userModel.Id);
         if (existingUser != null)
         {
            existingUser.LastName = userModel.LastName;
            existingUser.FirstName = userModel.FirstName;
            existingUser.Email = userModel.Email;
            existingUser.PasswordHash = userModel.PasswordHash;
            existingUser.Username = userModel.Username;
         }
      }

      public void PutUser(UserAddModel userAddModel)
      {
         userAddModel.Id = idGenerator.GetNextId();
         var userEntity = new UserEntity()
         {
            Id = userAddModel.Id,
            LastName = userAddModel.LastName,
            FirstName = userAddModel.FirstName,
            Email = userAddModel.Email,
            PasswordHash = userAddModel.PasswordHash,
            Username = userAddModel.Username
         };
         _users.Add(userEntity);
      }

      public void DeleteUser(UserEntity userModel)
      {
         _users.Remove(userModel);
      }

      public void DeleteAllUsers(UserEntity userModel)
      {
         _users.Clear();
      }

      public UserRepository(IdGenerator idGenerator)
      {
         this.idGenerator = idGenerator;
      }
   }
}   
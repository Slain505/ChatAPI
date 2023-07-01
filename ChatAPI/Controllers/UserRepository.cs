using System.Collections.Generic;
using ChatAPI.Infrastructure.Users;

namespace ChatAPI
{
   public class UserRepository : IUserRepository
   {
      private List<UserEntity> _users = new List<UserEntity>();

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
         }
      }

      public void PutUser(UserEntity userModel)
      {
         _users.Add(userModel);
      }

      public void DeleteUser(UserEntity userModel)
      {
         _users.Remove(userModel);
      }

      public void DeleteAllUsers(UserEntity userModel)
      {
         _users.Clear();
      }
   }
}   
using System.Collections.Generic;

namespace ChatAPI
{
   public class UserRepository : IUserRepository
   {
      private List<UserModel> _users = new List<UserModel>();

      public UserRepository()
      {
         _users = new List<UserModel>();
      }
      
      public UserModel GetUser(int id)
      {
         return _users.Find(u => u.Id == id);
      }

      public IEnumerable<UserModel> GetUserList()
      {
         return _users;
      }

      public void UpdateUser(UserModel userModel)
      {
         var existingUser = _users.Find(u => u.Id == userModel.Id);
         if (existingUser != null)
         {
            existingUser.LastName = userModel.LastName;
            existingUser.FirstName = userModel.FirstName;
            existingUser.Email = userModel.Email;
            existingUser.Password = userModel.Password;
         }
      }

      public void PutUser(UserModel userModel)
      {
         _users.Add(userModel);
      }

      public void DeleteUser(UserModel userModel)
      {
         _users.Remove(userModel);
      }
   }
}   
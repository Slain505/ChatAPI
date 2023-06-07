using System.Collections.Generic;

namespace ChatAPI
{
   public class User
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
   }

   public class UserRepository : IUserRepository
   {
      /*private static UserRepository _instance;
      private static readonly object _lock = new object();*/
      private List<User> _users = new List<User>();

      public UserRepository()
      {
         _users = new List<User>();
      }

      /*private static UserRepository Instance
      {
         get
         {
            if (_instance == null)
            {
               lock (_lock)
               {
                  if (_instance == null)
                  {
                     _instance = new UserRepository();
                  }
               }
            }

            return _instance;
         }
      }*/

      public User GetUser(int id)
      {
         return _users.Find(u => u.Id == id);
      }

      public IEnumerable<User> GetUserList()
      {
         return _users;
      }

      public void UpdateUser(User user)
      {
         var existingUser = _users.Find(u => u.Id == user.Id);
         if (existingUser != null)
         {
            existingUser.LastName = user.LastName;
            existingUser.FirstName = user.FirstName;
            existingUser.Email = user.Email;
         }
      }

      public void PutUser(User user)
      {
         _users.Add(user);
      }

      public void DeleteUser(User user)
      {
         _users.Remove(user);
      }
   }
}   
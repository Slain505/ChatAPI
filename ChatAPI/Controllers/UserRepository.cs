using System.Collections.Generic;

namespace ChatAPI
{
   public class User : IUsers
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
   }
   //Use UserRepository instead of UserList
   public class UserRepository
   {
      private static UserRepository _instance;
      private static readonly object _lock = new object();
      private List<IUsers> _users = new List<IUsers>();

      private UserRepository()
      {
         _users = new List<IUsers>();
      }

      private static UserRepository Instance
      {
         get
         {
            if (_instance == null)
            {
               lock (_lock)
               {
                  if (_instance == null)
                  {
                     _instance = new UserList();
                  }
               }
            }

            return _instance;
         }
      }
      //Add GetUserList(all users in the list)
      public IUsers GetUser(int id)
      {
         return _users.Find(u => u.Id == id);
      }
      //UpdateUser
      public void SetUser(IUsers user)
      {
         var existingUser = _users.Find(u => u.Id == user.Id);
         if (existingUser != null)
         {
            existingUser.LastName = user.LastName;
            existingUser.FirstName = user.FirstName;
            existingUser.Email = user.Email;
         }
         else //Delete this statement (Only PUT left) 
         {
            _users.Add(user);
         }
      }

      public void PutUser(IUsers user)
      {
         _users.Add(user);
      }
   }
}   
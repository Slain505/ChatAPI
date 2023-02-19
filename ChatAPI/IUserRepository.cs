using System.Collections.Generic;

namespace ChatAPI
{
    public interface IUserRepository 
    {
        void PutUser(User user);
        void UpdateUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetUserList();


    }
}
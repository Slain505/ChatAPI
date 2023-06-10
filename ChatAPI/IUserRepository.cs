using System.Collections.Generic;

namespace ChatAPI
{
    public interface IUserRepository 
    {
        void PutUser(UserModel userModel);
        void UpdateUser(UserModel userModel);
        void DeleteUser(UserModel userModel);
        UserModel GetUser(int id);
        IEnumerable<UserModel> GetUserList();
    }
}
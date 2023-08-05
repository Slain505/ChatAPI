using System.Collections.Generic;
using ChatAPI.Infrastructure.Users;

namespace ChatAPI
{
    public interface IUserRepository 
    {
        void PutUser(UserAddModel userAddModel);
        void UpdateUser(UserEntity userModel);
        void DeleteUser(UserEntity userModel);
        void DeleteAllUsers(UserEntity userModel);
        UserEntity GetUser(int id);
        IEnumerable<UserEntity> GetUserList();
    }
}
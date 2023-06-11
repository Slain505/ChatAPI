using System.Collections.Generic;
using ChatAPI.Infrastructure.Users;

namespace ChatAPI
{
    public interface IUserRepository 
    {
        void PutUser(UserEntity userModel);
        void UpdateUser(UserEntity userModel);
        void DeleteUser(UserEntity userModel);
        UserEntity GetUser(int id);
        IEnumerable<UserEntity> GetUserList();
    }
}
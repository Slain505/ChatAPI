namespace ChatAPI.Infrastructure.Users
{
    public class UserEntity
    {
        /// <summary>
        /// Data which would be persisted in server
        /// </summary>
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; } 
        
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string Username { get; set; }
    }
}
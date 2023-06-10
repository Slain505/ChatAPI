namespace ChatAPI.Infrastructure.Users
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        protected internal string Password { get; set; }
    }
}
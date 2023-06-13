namespace ChatAPI.Models
{
    public class UserResponseModel
    {
        /// <summary>
        /// Data transfer object to return to the client information about user
        /// </summary>
        public int Id { get; set; }
        
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        public string Email { get; set; }
    }
}
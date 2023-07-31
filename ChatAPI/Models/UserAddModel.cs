using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Infrastructure.Users
{
    public class UserAddModel
    {
        /// <summary>
        /// Data which would be added to server
        /// </summary>
        
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; } 
        
        public string Email { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string Username { get; set; }
    }
}
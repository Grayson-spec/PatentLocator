// Backend/Models/User.cs
namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Will be hashed later
        public string Role { get; set; }
    }
}
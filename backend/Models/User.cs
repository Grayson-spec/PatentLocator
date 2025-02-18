// Backend/Models/User.cs
namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; } // Will be hashed later
        public required string Role { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class SavedPatent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PatentId { get; set; }

        public DateTime SavedDate { get; set; }

        // REMOVE THESE ENTIRELY
        // public User User { get; set; }
        // public Patent Patent { get; set; }
    }
}
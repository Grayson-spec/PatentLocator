// Backend/Models/Patent.cs
namespace backend.Models
{
    public class Patent
    {
        public int Id { get; set; }
        public required string PatentNumber { get; set; }
        public required string Title { get; set; }

        public required string Inventor { get; set; }
        public DateTime PublicationDate { get; set; }
        
    }
}
// Backend/Models/Patent.cs
namespace Backend.Models
{
    public class Patent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Inventor { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PatentNumber { get; set; }
    }
}
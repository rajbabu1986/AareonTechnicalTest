using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public int PersonId { get; set; }
    }
}

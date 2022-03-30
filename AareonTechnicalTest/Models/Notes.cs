using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; private set; }

        public string NoteText { get; set; }

        public int TicketId { get; set; }

        public int PersonId { get; set; }

    }
}

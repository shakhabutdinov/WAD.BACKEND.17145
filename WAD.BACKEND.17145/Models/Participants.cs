using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._17145.Models
{
    public class Participants
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Participant name is required")]
        public string ParticipantName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "TicketType is required")]
        public string TicketType { get; set; }

        public int? EventId { get; set; }

        [ForeignKey("EventId")]
        public Events? Events { get; set; }
    }
}

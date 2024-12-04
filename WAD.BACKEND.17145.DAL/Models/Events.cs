using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._17145.Models
{
    public class Events
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "EventName is required")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        public string Venue { get; set; }


        [Required(ErrorMessage = "Organizer is required")]
        public string Organizer { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FredsBoats.Web.Models
{
    [Table("boat")]
    public class Boat
    {
        [Key]
        [Column("boatid")]
        public int BoatId { get; set; }

        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Column("hour_rate")]
        public float HourRate { get; set; }

        [Column("daily_rate")]
        public float DailyRate { get; set; }

        // Foreign Keys
        [Column("fkcategoryid")]
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Column("fkcolourid")]
        public int ColourId { get; set; }

        [ForeignKey("ColourId")]
        public BoatColour? BoatColour { get; set; }

        // Navigation for Reservations
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Comment> Comments {get;set;} = new List<Comment>();
    }
}
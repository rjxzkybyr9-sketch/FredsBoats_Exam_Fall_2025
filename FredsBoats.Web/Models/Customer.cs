using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FredsBoats.Web.Models
{
    [Table("customer")]
    public class Customer
    {
        // ACSC384 - To Do - Customer Class

        // Navigation
        public ICollection<CustReservation> CustReservations { get; set; } = new List<CustReservation>();
    }
}
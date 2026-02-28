using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CateringCo.Models
{
    public class CateringRequestModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; } = "";
        [StringLength(100)]
        public string LastName { get; set; } = "";
        [EmailAddress]
        public string Email { get; set; } = "";
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        [Range(1, 500, ErrorMessage = "We can only accomodate up to 500 guests, we apologize")]
        public int NumberOfGuests { get; set; }
        [StringLength(500)]
        public string SpecialRequests { get; set; } = "";
    }
}

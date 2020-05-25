using System.ComponentModel.DataAnnotations;
namespace ACWS_Data.Models
{
    public class CheckModel
    {
        public int ParticipantID { get; set; }

        [Required]
        [MinLength(8), MaxLength(8)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string SerialNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }
}
using System.ComponentModel.DataAnnotations;

namespace CharaGach.Models
{
    public class Admins
    {
        [Key]
        public int adminID { get; set; }
        public required string adminName{ get; set; }
        public required string adminNumber { get; set; }
        public required string adminEmail { get; set; }
        public required string adminPassword { get; set; }
        
    }
}

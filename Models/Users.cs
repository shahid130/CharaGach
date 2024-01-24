using System.ComponentModel.DataAnnotations;

namespace CharaGach.Models
{
    public class Users
    {
        [Key]
        public int userID { get; set; }
        public required string userName { get; set; } 
        public required string userEmail { get; set; }
        public required string userNumber { get; set; }
        public required string userAdress { get; set; }
        public required string userPassword { get; set; }
    }
}

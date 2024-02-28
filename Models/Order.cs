using System.ComponentModel.DataAnnotations;

namespace CharaGach.Models
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }
        public int userID { get; set; }
        public int plantID { get; set; }
        public int plantAmount { get; set; }
    }
}

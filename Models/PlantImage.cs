using System.ComponentModel.DataAnnotations;

namespace CharaGach.Models
{
    public class PlantImage
    {
        [Key]
        public int plantID { get; set; }
        public required string plantName { get; set; }
        public required string plantDetails { get; set; }
        public required string plantType { get; set; }
        public required decimal plantPrice { get; set; }
        public required int plantQuantity { get; set; }
        public required string plantSize { get; set; }
        public IFormFile photo { get; set; }
    }
}

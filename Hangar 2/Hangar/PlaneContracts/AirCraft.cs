using System.ComponentModel.DataAnnotations;

namespace Hangar.PlaneContracts
{
    public class AirCraft
    {
        [Required]
        public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string StorageData { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
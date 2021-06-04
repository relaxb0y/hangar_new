using System.ComponentModel.DataAnnotations;

namespace Hangar.HangarContracts
{
    public class Hangar
    {
        [Required]
        public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string Location { get; set; }
    }
}
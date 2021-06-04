using System.ComponentModel.DataAnnotations;

namespace Hangar.PlaneContracts
{
    public class UpdateDescription
    {
        [Required]
        public string Description { get; set; }
    }
}
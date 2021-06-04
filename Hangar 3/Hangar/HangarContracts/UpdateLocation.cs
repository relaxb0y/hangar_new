using System.ComponentModel.DataAnnotations;

namespace Hangar.HangarContracts
{
    public class UpdateLocation
    {
        [Required]
        public string Location { get; set; }
    }
}
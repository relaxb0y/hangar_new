using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hangar.Dao.Hangar;

namespace Hangar.Dao.AirCraft
{
    [Table("aircrafts")]
    public class AirCraftDto
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("storageData")]
        public string StorageData { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [ForeignKey("Hangar")] 
        [Column("Hangar_id")]
        public int HangarId { get; set; }
        public HangarDto Hangar { get; set; }
    }
}
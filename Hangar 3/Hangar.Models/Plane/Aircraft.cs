namespace Hangar.Models.Plane
{
    public class AirCraft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StorageData { get; set; }
        public string Description { get; set; }
        public int HangarId { get; set; }
    }
}
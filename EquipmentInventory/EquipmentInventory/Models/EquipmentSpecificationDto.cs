namespace EquipmentInventory.Models
{
    public class EquipmentSpecificationDto
    {
        public int Id { get; set; }
        public string Case { get; set; }
        public string Processor { get; set; }
        public string HardDrive { get; set; }
        public string Ram { get; set; }
        public string GraphicCard { get; set; }
        public string NetworkCard { get; set; }
        public string SoundCard { get; set; }
    }
}
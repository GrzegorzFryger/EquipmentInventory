using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    public class EquipmentSpecification
    {
        [Key]
        public Guid Id { get; set; }
        public string Case { get; set; }
        public string Processor { get; set; }
        public string HardDrive { get; set; }
        public string Ram { get; set; }
        public string GraphicCard { get; set; }
        public string NetworkCard { get; set; }
        public string SoundCard { get; set; }
    }
}
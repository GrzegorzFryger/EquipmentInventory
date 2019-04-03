using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    public class EquipmentSpecification
    {
        [Key]
        public int Id { get; set; }
        public string Case { get; set; }
        public string Processor { get; set; }
        public string HardDrive { get; set; }
        public string Ram { get; set; }
        public string GraphicCard { get; set; }
        public string NetworkCard { get; set; }
        public string SoundCard { get; set; }
        
        
        public ICollection<Equipment> Equipments { get; set; }
    }
}
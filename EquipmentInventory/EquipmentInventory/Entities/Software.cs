using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EquipmentInventory.Context;

namespace EquipmentInventory.Entities
{
    public class Software : IBasicEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        
        
        public Invoice Invoice { get; set; }
        
        public ICollection<EquipmentSoftware> EquipmentSoftwares { get; set; }
    }
}
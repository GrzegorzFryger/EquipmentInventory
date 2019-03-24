using System;
using System.ComponentModel.DataAnnotations;
using EquipmentInventory.Context;

namespace EquipmentInventory.Entities
{
    public class Software
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public Invoice Invoice { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public Model Model { get; set; }

        public Warehouse CurrentLocalization { get; set; }
        public User CurrentUser { get; set; }
        public EquipmentSpecification Specification { get; set; }
        public TypeEquipment TypeEquioment { get; set; }
        public Invoice Invoice { get; set; }
        public EquipmentHistory History { get; set; }
        
        public ICollection <EquipmentSoftware> EquipmentSoftwares { get; set;} 




    }

}    
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        public ICollection<Equipment> Equipments { get; set; }
    }
}
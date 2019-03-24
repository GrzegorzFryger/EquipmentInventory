using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    public class Monitor : Equipment
    {
        
        [Key]
        public string Sn { get; set; }
        public string Description { get; set; }
        public Invoice Invoice { get; set; }
    }
}
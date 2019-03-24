using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    public class Desktop : Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Sn { get; set; }
        public EquipmentSpecification Specification { get; set; }
        public string Description { get; set; }
        public Invoice Invoice { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    public class EquipmentHistory : IBasicEntity
    {
        [Key]
        public int Id { get;  set; }
        public DateTime Date { get;  set; }
        
        public int LocalizationId { get; set; }
        public Warehouse Localization { get;  set; }
        
        
        /*Relations*/
        public Equipment Equipment { get; set; }
        
        
        
        
    }
}
using System;

namespace EquipmentInventory.Models
{
    public class EquipmentHistoryDto
    {
        public  int Id { get;  set; }
        public DateTime Date { get;  set; }
        public WarehouseDto Localization { get; set; }
    }
}
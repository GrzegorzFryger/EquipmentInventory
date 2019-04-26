using System.Collections.Generic;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Models
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public CompanyDto Company { get; set; }
        public ModelDto Model { get; set; }
        public WarehouseDto CurrentLocalization { get; set; }
        public UserDto CurrentUser { get; set; }
        public EquipmentSpecificationDto Specification { get; set; }
        public TypeEquipment TypeEquioment { get; set; }
        public InvoiceDto Invoice { get; set; }
        public List<EquipmentHistoryDto> History { get; set; }
        
    }
}
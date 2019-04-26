using System;

namespace EquipmentInventory.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string InvoiceNumber { get; set; }
       
        public DateTime Date { get; set; }
    }
}
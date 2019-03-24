using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Entities
{
    public class Invoice 
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string InvoiceNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Entities
{
    public class Invoice : IBasicEntity
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string InvoiceNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public ICollection<Equipment> Equipments { get; set; }
        public ICollection<Software> Softwares { get; set; }
        
    }
}
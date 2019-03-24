using EquipmentInventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Context
{
    public class InventoryEquipmentContext : DbContext
    {
      
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Desktop> Desktops { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Printer>  Printers{ get; set; }
         
        
        public InventoryEquipmentContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                
        }
    }
}
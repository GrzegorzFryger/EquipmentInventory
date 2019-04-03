using EquipmentInventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Context
{
    public class InventoryEquipmentContext : DbContext
    {

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EquipmentHistory> EquipmentHistories { get; set; }
        public DbSet<EquipmentSpecification>  EquipmentSpecifications{ get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Model>Models  { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Role> UserRoles { get; set; }
        
      
         
        
        public InventoryEquipmentContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Equipments);
            
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Model)
                .WithMany(m => m.Equipments);
            
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.CurrentLocalization)
                .WithMany(c => c.Equipments);
            
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.CurrentUser)
                .WithMany(c => c.Equipments);
            
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Specification)
                .WithMany(s => s.Equipments);
            
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Invoice)
                .WithMany(i => i.Equipments);
            
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.History)
                .WithOne(h => h.Equipment)
                .HasForeignKey<EquipmentHistory>(h=> h.LocalizationId);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new {ur.RoleId, ur.UserId});

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRole)
                .HasForeignKey(ur => ur.RoleId);
            
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRole)
                .HasForeignKey(ur => ur.UserId);


            modelBuilder.Entity<User>().HasOne(u => u.Localization)
                .WithMany(m => m.Users);

            modelBuilder.Entity<EquipmentHistory>()
                .HasOne(h => h.Localization)
                .WithMany(l => l.EquipmentHistories);


            modelBuilder.Entity<Software>().HasOne(s => s.Invoice)
                .WithMany(i => i.Softwares);

            modelBuilder.Entity<EquipmentSoftware>().HasKey(eq => new {eq.SoftwareId, eq.EquipmentId});

            
            modelBuilder.Entity<EquipmentSoftware>()
                .HasOne(eq => eq.Software)
                .WithMany(s => s.EquipmentSoftwares)
                .HasForeignKey(eq => eq.SoftwareId);
            
            modelBuilder.Entity<EquipmentSoftware>()
                .HasOne(eq => eq.Equipment)
                .WithMany(e => e.EquipmentSoftwares)
                .HasForeignKey(eq => eq.EquipmentId);

            
           
            
            base.OnModelCreating(modelBuilder);
        }

      
    }
}
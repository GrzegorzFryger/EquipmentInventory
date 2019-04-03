using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    [Serializable]
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public string Mpk { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Name { get; set; }
        
        public ICollection<User> Users { get; set; }
        public ICollection< Equipment > Equipments { get; set; }
        public ICollection<EquipmentHistory> EquipmentHistories { get; set; }
    }
}
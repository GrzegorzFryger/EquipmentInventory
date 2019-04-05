using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    
    
    
    
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType((DataType.Password))]
        public string Password { get; set; }
        
        public Warehouse Localization { get; set;  }
        
        public ICollection<UserRole> UserRole { get; set; }
        

        public ICollection<Equipment> Equipments { get; set; }
        //array with equipment 
    }
}
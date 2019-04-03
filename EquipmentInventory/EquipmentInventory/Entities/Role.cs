using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventory.Entities
{
    
    public enum RoleType
    {
        Admin,User
       
       
    }
    
    public class Role
    {
          [Key]
         public int Id { get; set; }
         public RoleType RoleType { get; set; }
         
         public ICollection<UserRole> UserRole { get; set; }
    }
}
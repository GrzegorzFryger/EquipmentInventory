namespace EquipmentInventory.Entities
{
    public class EquipmentSoftware 
    {
       public int EquipmentId { get; set; }
       public Equipment Equipment { get; set; }
       
       public int SoftwareId { get; set; }
       public Software Software { get; set; }
    }
}
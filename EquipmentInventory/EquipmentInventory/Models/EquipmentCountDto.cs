namespace EquipmentInventory.Models
{
    public class EquipmentCountDto
    {
        public string TypeEquipment;
        public int AvailableEquipment;
        public int TotalEquipment;

        public EquipmentCountDto(string typeEquipment, int availableEquipment, int totalEquipment)
        {
            TypeEquipment = typeEquipment;
            AvailableEquipment = availableEquipment;
            TotalEquipment = totalEquipment;
        }
    }
}
namespace NB.DTC.Aptos.InventoryService.Models
{
    public class ComponentCheckModel
    {
        public string ComponentName { get; set; }
        public ComponentStatus Status { get; set; }
        public string Message { get; set; }

    }
}

namespace NB.DTC.Aptos.InventoryService.Models
{
    public enum ComponentStatus
    {
        Running,
        Down,
        AccessDenied,
        Error
    }
}
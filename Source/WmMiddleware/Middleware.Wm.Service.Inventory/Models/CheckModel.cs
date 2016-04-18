namespace Middleware.Wm.Service.Inventory.Models
{
    public class ComponentCheckModel
    {
        public string ComponentName { get; set; }
        public ComponentStatus Status { get; set; }
        public string Message { get; set; }

    }
}

namespace Middleware.Wm.Service.Inventory.Models
{
    public enum ComponentStatus
    {
        Running,
        Down,
        AccessDenied,
        Error
    }
}
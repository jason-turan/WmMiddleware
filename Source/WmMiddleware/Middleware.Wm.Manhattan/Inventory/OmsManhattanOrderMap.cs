using System;

namespace Middleware.Wm.Manhattan.Inventory
{
    public class OmsManhattanOrderMap
    {
        public string OmsOrderNumber { get; set; }
        public string WmOrderNumber { get; set; }
        public DateTime Created { get; set; }
        public string Company { get; set; }
    }
}

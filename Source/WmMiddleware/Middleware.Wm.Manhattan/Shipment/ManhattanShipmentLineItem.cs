using Dapper.Contrib.Extensions;

namespace Middleware.Wm.Manhattan.Shipment
{
    public partial class ManhattanShipmentLineItem
    {
        [Write(false)]
        public string ProductClass { get; set;  }
    }
}

using System;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Manhattan.Extensions;
using WmMiddleware.InventorySync.Models.Generated;

namespace Middleware.Wm.InventorySync.Models
{

    [Table("StlInventory")]
    public class StlInventory
    {
        private readonly ManhattanInventorySync _manhattanInventorySync;
        private readonly DateTime _inventoryDateTime;

        public StlInventory(DateTime inventoryDate, ManhattanInventorySync manhattanInventorySync)
        {
            _manhattanInventorySync = manhattanInventorySync;
            _inventoryDateTime = inventoryDate;
        }

        public string Upc
        {
            get { return _manhattanInventorySync.MiscellaneousChar2; }
        }

        public string Style
        {
            get { return _manhattanInventorySync.SeasonYear + _manhattanInventorySync.Style; }
        }

        public string Size
        {
            get { return _manhattanInventorySync.SecDimension.ConvertFromManhattanSize(); }
        }

        public string Attribute
        {
            get { return _manhattanInventorySync.Color; }
        }

        public int Quantity
        {
            get { return (int)_manhattanInventorySync.WarehouseQuantity; }
        }

        public int ManhattanInventorySyncTransactionNumber
        {
            get { return _manhattanInventorySync.TransactionNumber; }
        }

        public DateTime InventoryDate
        {
            get { return _inventoryDateTime; }
        }

        public DateTime ModifiedDate
        {
            get { return _inventoryDateTime; }
        }
    }
}
 
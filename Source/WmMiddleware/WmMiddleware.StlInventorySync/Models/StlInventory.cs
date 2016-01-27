using System;
using Dapper.Contrib.Extensions;
using WmMiddleware.Common.Extensions;
using WmMiddleware.InventorySync.Models.Generated;

namespace WmMiddleware.StlInventorySync.Models
{

    [Table("StlInventory")]
    public class StlInventory
    {
        private readonly ManhattanInventorySync _manhattanInventorySync;
        private readonly DateTime _inventoryDateTime;

        public StlInventory(ManhattanInventorySync manhattanInventorySync)
        {
            _manhattanInventorySync = manhattanInventorySync;
            _inventoryDateTime = DateTime.Now;
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
            get { return _manhattanInventorySync.SecDimension.ToEcommSize(); }
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

    }
}

using System;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public abstract class GeneralLedgerInventoryTransaction
    {
        public DateTime BatchDate
        {
            get
            {
                var now = DateTime.Now;
                return new DateTime(now.Year, now.Month, now.Day);
            }
        }

        public string IntegrationStatus
        {
            get { return "NEW"; }
        }

        public string UnitOfMeasure
        {
            get { return "Each"; }
        }

        public string BatchSource
        {
            get { return "NBXWEB InventoryAdjustment_Interface"; }
        }
    }
}

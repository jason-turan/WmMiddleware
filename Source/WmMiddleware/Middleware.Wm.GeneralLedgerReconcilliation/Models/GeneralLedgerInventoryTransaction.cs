using System;
using Middleware.Wm.Configuration;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public abstract class GeneralLedgerInventoryTransaction
    {
        private readonly IConfigurationManager _configurationManager;

        protected GeneralLedgerInventoryTransaction(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

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

        protected string GetVarianceAccountByProductClass(string productClass)
        {
            switch (productClass.ToUpper())
            {
                case "APPAREL":
                    return _configurationManager.GetKey<string>(ConfigurationKey.GeneralLedgerVarianceAccountApparel);
                case "ACCESSORY":
                    return _configurationManager.GetKey<string>(ConfigurationKey.GeneralLedgerVarianceAccountAccessory);
                default:
                    return _configurationManager.GetKey<string>(ConfigurationKey.GeneralLedgerVarianceAccountDefault);
            }
        }
    }
}

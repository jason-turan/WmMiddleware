using System.Collections.Generic;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public interface IDatabaseRepository
    {
        void InsertIntegrationInventoryAdjustment(DatabaseIntegrationsInventoryAdjustment databaseIntegrationsInventoryAdjustment);
        IList<GeneralLedgerTransactionReasonCodeMap> GetGeneralLedgerTransactionReasonCodeMap();
        void InsertPixGeneralLedgerProcessing(PixGeneralLedgerProcessing pixGeneralLedgerProcessing);
        int InsertDatabasePoReceiptHeader(DatabasePurchaseOrderReceiptHeader databasePurchaseReceiptHeader);
        int InsertDatabasePurchaseOrderReceiptDetail(DatabasePurchaseOrderReceiptDetail databasePurchaseOrderDetailInterface);
        void InsertDatabasePurchaseOrderReceiptDetailLineItem(DatabasePurchaseOrderReceiptDetailLineItem databasePurchaseOrderReceiptDetailLineItem);
    }
}
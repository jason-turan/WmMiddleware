using System.Collections.Generic;
using Middleware.Wm.Aurora.Shipment.Models;

namespace Middleware.Wm.Aurora.Shipment.Repository
{
    public interface IDatabaseKioskOrderExportRepository
    {
        void InsertDatabaseKioskOrderExport(IList<DatabaseKioskOrderExport> kioskOrderExports);

        void InsertDatabaseKioskOrderDetailExport(IList<DatabaseKioskOrderDetailExport> kiosKioskOrderDetailExports);
        
        IList<DatabaseKioskOrderExport> GetDatabaseKioskOrderExports();

        IList<DatabaseKioskOrderDetailExport> GetDatabaseKioskOrderDetailExports();
    }
}

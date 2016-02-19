using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public class GeneralLedgerReconcilliationRepository : IGeneralLedgerReconcilliationRepository
    {
        public IList<GeneralLedgerTransactionReasonCodeMap> GetGeneralLedgerTransactionReasonCodeMap()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                return connection.Query<GeneralLedgerTransactionReasonCodeMap>("sp_GetGeneralLedgerTransactionReasonCodeMap", 
                                                                               commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}

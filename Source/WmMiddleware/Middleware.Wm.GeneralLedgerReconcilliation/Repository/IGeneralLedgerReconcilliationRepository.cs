using System.Collections.Generic;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public interface IGeneralLedgerReconcilliationRepository
    {
        IList<GeneralLedgerTransactionReasonCodeMap> GetGeneralLedgerTransactionReasonCodeMap();
    }
}

using System.Transactions;

namespace Middleware.Wm.Configuration.Transaction
{
    public class Scope
    {
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted, 
                Timeout = TransactionManager.MaximumTimeout
            };

            // http://blogs.msdn.com/b/dbrowne/archive/2010/06/03/using-new-transactionscope-considered-harmful.aspx
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}

using Middleware.Jobs;

namespace WmMiddleware.TransferControl
{
    interface ITransferControlJob : IUnitOfWork
    {
        void SetDirectories();
    }
}

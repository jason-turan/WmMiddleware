namespace WmMiddleware.ProductReceiving.Repositories
{
    public interface IStoreReader
    {
        void GetClosestStore(string zipCode);
    }
}

namespace WmMiddleware.Configuration.Manhattan
{
    public interface IManhattanConfiguration : IConfigurationManager
    {
        long GetBatchControlNumber();
        string GetPath(string filePrefix, long batchControlNumber);
    }
}

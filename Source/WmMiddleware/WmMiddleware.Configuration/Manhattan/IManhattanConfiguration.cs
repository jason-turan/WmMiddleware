namespace WmMiddleware.Configuration.Manhattan
{
    public interface IManhattanConfiguration : IConfigurationManager
    {
        long GetBatchControlNumber(BatchControlNumberType type);
        string GetPath(string filePrefix, long batchControlNumber);
    }
}

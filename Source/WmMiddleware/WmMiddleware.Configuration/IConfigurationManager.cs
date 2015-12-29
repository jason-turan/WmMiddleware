namespace WmMiddleware.Configuration
{
    public interface IConfigurationManager
    {
        T GetKey<T>(string key, T defaultValue = default(T));
    }
}

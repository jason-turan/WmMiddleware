namespace WmMiddleware.Common.Locations
{
    public interface ICountryReader
    {
        int GetCountryCode(string countryAbbreviation);
    }
}

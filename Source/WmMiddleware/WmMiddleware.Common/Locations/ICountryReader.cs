namespace WmMiddleware.Common.Locations
{
    public interface ICountryReader
    {
        int GetCountryCode(string countryAbbreviation);
        string GetCountryAbbreviation(int countryCode);
    }
}

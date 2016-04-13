namespace Middleware.Wm.Locations
{
    public interface ICountryReader
    {
        int GetCountryCode(string countryAbbreviation);
        string GetCountryAbbreviation(int countryCode);
    }
}

using Middleware.Wm.PixReturn.Models;

namespace Middleware.Wm.PixReturn.Repository
{
    public interface IDatabaseRowReturnRepository
    {
        void InsertRowReturn(DatabaseRowReturn databaseRowReturn);

        string GetCompanyFromOrderNumber(string orderNumber);
    }
}
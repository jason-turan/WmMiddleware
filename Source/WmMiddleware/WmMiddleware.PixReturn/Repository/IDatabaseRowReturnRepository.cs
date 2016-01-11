using WmMiddleware.PixReturn.Models;

namespace WmMiddleware.PixReturn.Repository
{
    public interface IDatabaseRowReturnRepository
    {
        void InsertRowReturn(DatabaseRowReturn databaseRowReturn);
    }
}
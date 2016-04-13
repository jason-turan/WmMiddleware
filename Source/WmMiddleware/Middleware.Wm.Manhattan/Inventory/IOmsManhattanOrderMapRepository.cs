namespace Middleware.Wm.Manhattan.Inventory
{
    public interface IOmsManhattanOrderMapRepository
    {
        void InsertOmsManhattanOrderMapRepository(OmsManhattanOrderMap omsManhattanOrderMap);
        OmsManhattanOrderMap GetOmsManhattanOrderMap(OmsManhattanOrderMapFindCriteria criteria);
    }
}

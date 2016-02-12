using System.Collections.Generic;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Inventory;

namespace Middleware.Wm.PickTicketConfirmation.Repositories
{
    public class ManhattanOrderWriter : IOrderWriter
    {
        private readonly IManhattanOrderRepository _manhattanOrderRepository;
        private readonly IManhattanOrderConfiguration _configuration;

        public ManhattanOrderWriter(IManhattanOrderRepository manhattanOrderRepository, IManhattanOrderConfiguration configuration)
        {
            _manhattanOrderRepository = manhattanOrderRepository;
            _configuration = configuration;
        }

        public void SaveOrders(IEnumerable<Order> orders)
        {
            var controlNumber = _configuration.GetBatchControlNumber();
            _manhattanOrderRepository.SaveOrders(orders, _configuration.GetHeaderFilePath(controlNumber), _configuration.GetDetailFilePath(controlNumber), _configuration.GetSpecialInstructionFilePath(controlNumber));
        }
    }
}

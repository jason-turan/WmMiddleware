using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Wm.DataFiles;
using Middleware.Wm.Locations;
using Middleware.Wm.Shipping;

namespace Middleware.Wm.Inventory.Manhattan
{
    public class ManhattanOrderRepository : IManhattanOrderRepository
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICountryReader _countryReader;

        private readonly DataFileRepository<ManhattanPickTicketHeader> _headerRepository = new DataFileRepository<ManhattanPickTicketHeader>();
        private readonly DataFileRepository<ManhattanPickTicketDetail> _detailRepository = new DataFileRepository<ManhattanPickTicketDetail>();

        public ManhattanOrderRepository(ICarrierReadRepository carrierReadRepository, ICountryReader countryReader)
        {
            _carrierReadRepository = carrierReadRepository;
            _countryReader = countryReader;
        }

        public ICollection<Order> GetOrders(string headerFileLocation, string detailsFileLocation, string instructionsFileLocation)
        {
            if (headerFileLocation == null)
            {
                throw new ArgumentNullException("headerFileLocation");
            }

            if (detailsFileLocation == null)
            {
                throw new ArgumentNullException("detailsFileLocation");
            }

            var headers = _headerRepository.Get(headerFileLocation);
            var details = _detailRepository.Get(detailsFileLocation);

            if (instructionsFileLocation != null)
            {
                throw new NotImplementedException();
            }

            var orders = headers.ToDictionary(h => h.PickticketControlNumber, h => h.ToOrder(_carrierReadRepository, _countryReader));

            foreach (var detail in details)
            {
                var lineItem = detail.ToLineItem();
                orders[detail.PickticketControlNumber].Items.Add(lineItem);
            }

            return orders.Values;
        }
    }
}

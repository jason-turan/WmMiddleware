using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Shipping;

namespace Middleware.Wm.Manhattan.Inventory
{
    public class ManhattanOrderRepository : IManhattanOrderRepository
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICountryReader _countryReader;
        private readonly IMainframeOrderConfiguration _configuration;
        private readonly ITransferControlManager _transferControlManager;

        private readonly DataFileRepository<ManhattanPickTicketHeader> _headerRepository = new DataFileRepository<ManhattanPickTicketHeader>();
        private readonly DataFileRepository<ManhattanPickTicketDetail> _detailRepository = new DataFileRepository<ManhattanPickTicketDetail>();
        private readonly DataFileRepository<ManhattanPickTicketInstruction> _instructionRepository = new DataFileRepository<ManhattanPickTicketInstruction>();

        public ManhattanOrderRepository(ICarrierReadRepository carrierReadRepository, 
                                        ICountryReader countryReader, 
                                        IMainframeOrderConfiguration configuration, 
                                        ITransferControlManager transferControlManager)
        {
            _carrierReadRepository = carrierReadRepository;
            _countryReader = countryReader;
            _configuration = configuration;
            _transferControlManager = transferControlManager;
        }

        public ICollection<Order> GetOrders(string headerFileLocation, string detailsFileLocation, string instructionsFileLocation)
        {
            if (headerFileLocation == null) throw new ArgumentNullException("headerFileLocation");
            if (detailsFileLocation == null) throw new ArgumentNullException("detailsFileLocation");

            var headers = _headerRepository.Get(headerFileLocation);
            var details = _detailRepository.Get(detailsFileLocation);

            var orders = headers.ToDictionary(h => h.PickticketControlNumber, h => h.ToOrder(_carrierReadRepository, _countryReader));

            foreach (var detail in details)
            {
                var lineItem = detail.ToLineItem();
                orders[detail.PickticketControlNumber].Items.Add(lineItem);
            }

            return orders.Values;
        }

        public void SaveOrders(IEnumerable<Order> orders, string headerFileLocation, string detailsFileLocation, string instructionsFileLocation)
        {
            if (headerFileLocation == null) throw new ArgumentNullException("headerFileLocation");
            if (detailsFileLocation == null) throw new ArgumentNullException("detailsFileLocation");
            if (instructionsFileLocation == null) throw new ArgumentNullException("instructionsFileLocation");

            var allOrders = orders.ToList();
            if (!allOrders.Any())
            {
                return;
            }

            var warehouseNumber = _configuration.GetWarehouseNumber();
            var companyNumber = _configuration.GetCompanyNumber();
            var warehouseAddress = _configuration.GetWarehouseAddress();
            var shipTo = _configuration.GetShipTo();

            var controlNumber = _configuration.GetBatchControlNumber();
            var batchControlNumber = warehouseNumber + controlNumber.ToString("D8");

            var detailList = new List<ManhattanPickTicketDetail>();
            var headerList = new List<ManhattanPickTicketHeader>();
            var instructionList = new List<ManhattanPickTicketInstruction>();
            
            foreach (var order in allOrders)
            {
                order.BillingAddress = warehouseAddress;

                headerList.Add(new ManhattanPickTicketHeader(order, batchControlNumber, companyNumber, warehouseNumber, shipTo, _countryReader, _carrierReadRepository));
                detailList.AddRange(CombineItems(order, batchControlNumber, companyNumber, warehouseNumber));
                var instructionControlNumber = 1;
                foreach (var instruction in order.SpecialInstructions)
                {
                    instructionList.Add(new ManhattanPickTicketInstruction("VA", "VA", instruction, batchControlNumber, order.ControlNumber, instructionControlNumber));
                    instructionControlNumber++;
                }
                instructionList.AddRange(_configuration.GetPickTicketInstructions(order, batchControlNumber, instructionControlNumber));
            }

            var headerPath = _configuration.GetHeaderFilePath(controlNumber);
            var detailPath = _configuration.GetDetailFilePath(controlNumber);
            var instructionPath = _configuration.GetSpecialInstructionFilePath(controlNumber);

            _headerRepository.Save(headerList, headerPath);
            _detailRepository.Save(detailList, detailPath);
            _instructionRepository.Save(instructionList, instructionPath);

            _transferControlManager.SaveTransferControl(batchControlNumber,
                                                        new List<string> { headerPath, detailPath, instructionPath },
                                                        _configuration.GetJobId());
        }


        private static IEnumerable<ManhattanPickTicketDetail> CombineItems(Order order, string batchControlNumber, string companyNumber, string warehouseNumber)
        {
            var itemGroups = order.Items.GroupBy(i => i.ItemSku);
            foreach (var itemGroup in itemGroups)
            {
                var combinedItem = itemGroup.First().Clone();
                combinedItem.Quantity = itemGroup.Sum(i => i.Quantity);
                yield return new ManhattanPickTicketDetail(combinedItem, batchControlNumber, order.ControlNumber, companyNumber, warehouseNumber);
            }
        }
    }
}

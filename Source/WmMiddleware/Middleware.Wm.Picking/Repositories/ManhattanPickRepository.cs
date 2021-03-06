﻿using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Wm.Configuration;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.Shipping;

namespace Middleware.Wm.Picking.Repositories
{
    public class ManhattanPickRepository : IOrderWriter
    {
        private readonly IPickConfiguration _configuration;
        private readonly DataFileRepository<ManhattanPickTicketDetail> _detailFileRepository = new DataFileRepository<ManhattanPickTicketDetail>();
        private readonly DataFileRepository<ManhattanPickTicketHeader> _headerFileRepository = new DataFileRepository<ManhattanPickTicketHeader>();
        private readonly DataFileRepository<ManhattanPickTicketInstruction> _instructionFileRepository = new DataFileRepository<ManhattanPickTicketInstruction>();
        private readonly ITransferControlManager _transferControlManager;
        private readonly IJobRepository _jobRepository;
        private readonly ICountryReader _countryReader;
        private readonly ICarrierReadRepository _carrierRepository;

        public ManhattanPickRepository(IPickConfiguration configuration, 
                                       ITransferControlManager transferControlManager,
                                       IJobRepository jobRepository,
                                       ICountryReader countryReader,
                                       ICarrierReadRepository carrierRepository)
        {
            _configuration = configuration;
            _jobRepository = jobRepository;
            _countryReader = countryReader;
            _carrierRepository = carrierRepository;
            _transferControlManager = transferControlManager;
        }

        public void SaveOrders(IEnumerable<Order> orders)
        {
            var allOrders = orders.ToList();
            if (!allOrders.Any())
            {
                return;
            }

            var detailList = new List<ManhattanPickTicketDetail>();
            var headerList = new List<ManhattanPickTicketHeader>();
            var instructionList = new List<ManhattanPickTicketInstruction>();

            var warehouseNumber = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber);
            var companyNumber = _configuration.GetKey<string>(ConfigurationKey.CompanyNumber);
            var warehouseAddress = _configuration.GetWarehouseAddress();

            var controlNumber = _configuration.GetBatchControlNumber();
            var batchControlNumber = warehouseNumber + controlNumber.ToString("D8");

            foreach (var order in allOrders)
            {
                order.BillingAddress = warehouseAddress;

                headerList.Add(new ManhattanPickTicketHeader(order, batchControlNumber, companyNumber, warehouseNumber, "CDS", _countryReader, _carrierRepository));
                detailList.AddRange(CombineItems(order, batchControlNumber, companyNumber, warehouseNumber));
                var instructionControlNumber = 1;
                foreach (var instruction in order.SpecialInstructions)
                {
                    instructionList.Add(new ManhattanPickTicketInstruction("VA", "VA", instruction, batchControlNumber, order.ControlNumber, instructionControlNumber));
                    instructionControlNumber++;
                }
                instructionList.AddRange(GetGlobalInstructions(order, batchControlNumber, instructionControlNumber));
            }

            var headerPath = _configuration.GetPath(ManhattanDataFileType.PickHeader, controlNumber);
            var detailPath = _configuration.GetPath(ManhattanDataFileType.PickDetail, controlNumber);
            var instructionPath = _configuration.GetPath(ManhattanDataFileType.PickSpecialInstructions, controlNumber);

            _headerFileRepository.Save(headerList, headerPath);
            _detailFileRepository.Save(detailList, detailPath);
            _instructionFileRepository.Save(instructionList, instructionPath);

            _transferControlManager.SaveTransferControl(batchControlNumber,
                                                        new List<string> { headerPath, detailPath, instructionPath },
                                                        _jobRepository.GetJob(JobKey.PickJob).JobId);
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

        private IEnumerable<ManhattanPickTicketInstruction> GetGlobalInstructions(Order order, string batchControlNumber, int instructionControlNumber)
        {
            var warehouseAddress = _configuration.GetWarehouseAddress();
            var phoneNumber = _configuration.GetKey<string>(ConfigurationKey.PhoneNumber);
            var upsAccountNumber = _configuration.GetKey<string>(ConfigurationKey.UpsAccountNumber);

            var isFromNewBalance = order.Company.Equals("NBWE", StringComparison.InvariantCultureIgnoreCase);
            var warehouseAddress1 = string.Format("{0,-50}{1}", "New Balance", warehouseAddress.Line1);
            var warehouseAddress3 = string.Format("{0,-50}{1,-5}{2,-11}{3}", warehouseAddress.City, warehouseAddress.State, warehouseAddress.Zip, "840");
            var dropshipLine = string.Format("{0,-21}{1,-29}DROPSHIP", "NBWEBEXPRESS", "ZZZZ");

            yield return new ManhattanPickTicketInstruction("VA", "OR", "NBUS", batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "UPS ACCOUNT#" + upsAccountNumber, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "APPLY CARTON STICKER AND INSERT", batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "RETURN CARD", batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS01" + phoneNumber, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS02" + (isFromNewBalance ? "newbalance.com" : string.Empty), batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS03" + order.OrderNumber, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS04" + order.OrderDate, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS05" /* + store website */, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS06" /* + ?? */, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS07" /* + ?? */, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("VA", "OR", "PS08" /* + ?? */, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("TP", "TP", warehouseAddress1, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("TP", "TP", string.Empty, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("TP", "TP", warehouseAddress3, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("MA", "MA", dropshipLine, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("MA", "MA", warehouseAddress.Line1, batchControlNumber, order.ControlNumber, instructionControlNumber++);
            yield return new ManhattanPickTicketInstruction("MA", "MA", warehouseAddress3, batchControlNumber, order.ControlNumber, instructionControlNumber);
        }
    }
}

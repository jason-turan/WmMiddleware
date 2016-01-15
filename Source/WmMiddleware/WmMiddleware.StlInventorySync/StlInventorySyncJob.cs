﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.InventorySync.Models;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.StlInventorySync.Repository;

namespace WmMiddleware.StlInventorySync
{
    public class StlInventorySyncJob : IStlInventorySyncJob
    {
        private readonly ILog _log;
        private readonly IStlInventoryRepository _stlInventoryRepository;
        private readonly IInventorySyncRepository _inventorySyncRepository;

        public StlInventorySyncJob(ILog log, IStlInventoryRepository stlInventory, IInventorySyncRepository inventorySyncRepository)
        {
            _log = log;
            _stlInventoryRepository = stlInventory;
            _inventorySyncRepository = inventorySyncRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var stlInvetorySyncLatest = _stlInventoryRepository.GetStlInventorySync().ToList();

            if (stlInvetorySyncLatest.Count > 0)
            {
                _stlInventoryRepository.InsertStlInventory(stlInvetorySyncLatest);

                _log.Debug("Inserted " + stlInvetorySyncLatest.Count() + " records from latest InventorySync data");

                _inventorySyncRepository.SetAsProcessed(new InventorySyncProcessing
                {
                    InventorySyncProcessingId = stlInvetorySyncLatest.First().InventorySyncProcessingId,
                    ProcessedDate = stlInvetorySyncLatest.First().InvDate
                });           
            }
            else
            {
                _log.Debug("No sync data for StlInventory!!!");
            }          
        }

    }
}

using Middleware.Wm.Service.Inventory.Domain.RibaSystem;
using Middleware.Wm.Service.Inventory.Models.Controllers;
using System.Web.Http;
using Middleware.Wm.Service.Inventory.Domain.RibaSystem.Models;
using System;

namespace NB.DTC.Aptos.InventoryService.Tests.Controllers
{
    public class RibaController : ApiController, IRibaSystem
    {
        public void SendPurchaseOrderReceipt(PurchaseOrderReceipt po)
        {
            throw new NotImplementedException();
        } 

    }
}

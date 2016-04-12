using NB.DTC.Aptos.InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace NB.DTC.Aptos.InventoryService.Tests.Controllers
{ 
    public class OmsController : ApiController
    {

        ///<summary>
        /// Inventory search by site and warehouse.
        ///</summary>
        /// <remarks>
        /// API used to search for Available To Sell inventory.  
        /// This service is used to confirm availability prior to processing orders or transfers that are sensitive to availability.  
        /// It also is used to identify the difference between what is Sellable and what is on-hand from a sales channel 
        /// perspective. 
        ///         
        /// </remarks>
        /// <returns>Inventory levels for the given parameters</returns>
        [HttpPost]
        [Route("Search/AvailableToSell")]
        [ActionName("Search/AvailableToSell")]
        public List<InventoryQuantity> SearchAvailableToSell(InventorySearchFilter filter)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("UpdateAvailableToSellInventory")]
        [ActionName("UpdateAvailableToSellInventory")]
        public void UpdateAvailableToSellInventory(UpdateInventoryRequest request)
        {
            throw new NotImplementedException();
        } 

    }

    
}

using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Models.Controllers;
using System.Collections.Generic;
using System.Web.Http;

namespace Middleware.Wm.Service.Inventory.Tests.Controllers
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
            return new List<InventoryQuantity>
            {
                new InventoryQuantity("1", "1", new Product("12345", "Style", "M", "E", "1994"), 1, 1)
            };
        }

        [HttpPost]
        [Route("UpdateAvailableToSellInventory")]
        [ActionName("UpdateAvailableToSellInventory")]
        public List<InventoryQuantity> UpdateAvailableToSellInventory(UpdateInventoryRequest request)
        {
            return new List<InventoryQuantity>
            {
                new InventoryQuantity("1", "1", new Product("12345", "Style", "M", "E", "1994"), 1, 1)
            };
        } 

    }

    
}

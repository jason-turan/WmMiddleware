﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Middleware.Wm.Service.Inventory.Domain;
using Middleware.Wm.Service.Inventory.Models;

namespace NB.DTC.Aptos.InventoryService.Tests
{
    [TestClass]
    public class PurchaseOrderEventHandlerTests
    {
        private PurchaseOrderEventHandler _eventHandlerToTest;
        private PurchaseOrderReceiptEvent _testReceivedEvent;

        [TestInitialize]
        public void TestInitilize()
        { 
            //_eventHandlerToTest = new PurchaseOrderEventHandler();
            //_testReceivedEvent = new PurchaseOrderReceiptEvent(
            //    "TEST",
            //    DateTime.Now,
            //    new List<ProductQuantity>(){
            //        CreateTestProduct("FOO",10)
            //    });
        }

        [TestMethod]
        public void OnReceivedShouldNotifySomeone()
        {
                        
        }

        private ProductQuantity CreateTestProduct(string name, int quantity)
        {
            return new ProductQuantity(new Product("1984"), quantity);
        }
    }
}

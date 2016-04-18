using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Middleware.Wm.Service.Inventory.Domain;
using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;

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
            _eventHandlerToTest = new PurchaseOrderEventHandler();
            _testReceivedEvent = new PurchaseOrderReceiptEvent(
                "TEST",
                DateTime.Now,
                new List<ProductQuantity>(){
                    CreateTestProduct("FOO",10)
                });
        }

        [TestMethod]
        public void OnReceivedShouldNotifySomeone()
        {
            _eventHandlerToTest.ReceivedOnLocation(_testReceivedEvent);
        }

        private ProductQuantity CreateTestProduct(string name, int quantity)
        {
            return new ProductQuantity(name, "s1", "10", "12", "1984",quantity);
        }
    }
}

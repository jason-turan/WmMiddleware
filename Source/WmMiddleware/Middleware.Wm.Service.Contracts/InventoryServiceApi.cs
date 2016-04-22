using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Wm.Service.Inventory.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace Middleware.Wm.Service.Contracts
{
    public class InventoryServiceApi : IIventoryServiceApi
    {
        private readonly string _baseUrl;  

        public InventoryServiceApi(string baseUrl)
        {
            _baseUrl = baseUrl; 
        }

        public void ReceivedOnLocation(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {
            var request = ConstructPostRequest("Order/ReceivedOnLocation", purchaseOrderReceiptEvent);
            Execute<object>(request);
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(_baseUrl);            
            var response = client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new ApplicationException(message, response.ErrorException);
                throw exception;
            }
            return response.Data;
        }
         
        private RestRequest ConstructPostRequest(string resource, object body)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = resource;
            request.JsonSerializer = new JsonSerializer();
            request.AddBody(body);
            return request;
        }

    }
}

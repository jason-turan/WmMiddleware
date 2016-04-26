using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Wm.Service.Inventory.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using Middleware.Wm.Service.Contracts.Models;

namespace Middleware.Wm.Service.Contracts
{
    public class InventoryServiceApiClient : IIventoryServiceApi
    {
        private readonly string _baseUrl;

        public InventoryServiceApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public void PurchaseOrderReceived(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {
            var request = ConstructPostRequest("Order/ReceivedOnLocation", purchaseOrderReceiptEvent);
            Execute<object>(request);
        }

        public void PurchaseOrderStocked(PurchaseOrderStockedEvent purchaseOrderStockedEvent)
        {
            var request = ConstructPostRequest("Order/Stocked", purchaseOrderStockedEvent);
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
            if (response.IsSuccessful())
            {
                return response.Data;
            }
            else
            {
                var message = ConstructExceptionMessage( response);
                throw new ApplicationException(message);
            }
        }

        public string ConstructExceptionMessage( IRestResponse response)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Response status: {0} {1} - {2}", (int)response.StatusCode, response.StatusCode, response.StatusDescription));
            sb.AppendLine("An error occurred while processing the request: " + response.StatusDescription);
            sb.AppendLine(response.Content);
            if (response.ErrorException != null)
            {
                var exceptionMessage = String.Format("An exception occurred while processing the request: {0}, Exception: {1}",
                              response.ErrorException.Message, response.ErrorException);
                sb.AppendLine(exceptionMessage);
            }
            return sb.ToString();
        }

        private RestRequest ConstructPostRequest(string resource, object body)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = resource;
            request.RequestFormat = DataFormat.Json;            
            request.JsonSerializer = new JsonSerializer();
            request.AddBody(body);
            return request;
        }

       
    }
}

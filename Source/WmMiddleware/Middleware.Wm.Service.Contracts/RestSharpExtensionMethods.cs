﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Contracts
{
    public static class RestSharpExtensionMethods
    {
        public static bool IsSuccessful(this IRestResponse response)
        {
            return response.StatusCode.IsSuccessStatusCode()
                && response.ResponseStatus == ResponseStatus.Completed;
        }

        public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
        {
            int numericResponse = (int)responseCode;
            return numericResponse >= 200
                && numericResponse <= 399;
        }
    }
}

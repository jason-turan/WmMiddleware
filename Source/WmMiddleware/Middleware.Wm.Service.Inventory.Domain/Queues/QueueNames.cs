using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public static class QueueNames
    {
        //Convention for queue names is {ControllerActionName}-{OperationName}

        public const string ReceivedOnLocationNotifyRiba= "receivedonlocation-notifyriba";


    }
}

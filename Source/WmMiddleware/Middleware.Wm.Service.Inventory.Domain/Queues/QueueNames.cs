namespace Middleware.Wm.Service.Inventory.Domain
{
    public static class QueueNames
    {
        //Convention for queue names is {ControllerActionName}-{OperationName}

        public const string ReceivedOnLocationNotifyRiba= "receivedonlocation-notifyriba";
        public const string CreateTransferIncrementOwnership = "createtransfer-incrementownership";

    }
}

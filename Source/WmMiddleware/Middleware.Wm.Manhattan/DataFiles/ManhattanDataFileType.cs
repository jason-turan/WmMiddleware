namespace Middleware.Wm.Manhattan.DataFiles
{
    public class ManhattanDataFileType
    {
        // shipment
        public const string ShipmentHeader = "O1";
        public const string ShipmentDetail = "O2";
        public const string CartonHeader = "O3";
        public const string CartonDetail = "O4";

        // pick
        public const string PickHeader = "I1";
        public const string PickDetail = "I2";
        public const string PickSpecialInstructions = "I3";

        // product receiving
        public const string ProductReceivingHeader = "I8";
        public const string ProductReceivingPoDetail = "I9";
        public const string ProductReceivingAsnDetail = "IB";

        // product updating
        public const string ProductUpdatingProductPath = "I5";

        // pix
        public const string PerpetualInventoryTransfer = "PX";
    }
}

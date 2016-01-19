namespace WmMiddleware.Configuration
{
    public static class ConfigurationKey
    {
        public const string CompanyNumber = "CompanyNumber";
        public const string WarehouseNumber = "WarehouseNumber";

        public const string AlertDistributionList = "Alert_DistributionList";
        public const string SmptServer = "SMPTServer";

        public const string PickInboundFileDirectory = "TransferControl_PickFileDirectory";

        public const string TransferControlInboundMasterFileFtpLocation = "TransferControl_InboundMasterFileFtpLocation";
        public const string TransferControlInboundMasterControlFilename = "TransferControl_InboundMasterControlFileName";
        public const string TransferControlInboundFtpLocation = "TransferControl_InboundFtpLocation";
        public const string TransferControlInboundFileDirectory = "TransferControl_InboundFileDirectory";
        public const string TransferControlInboundFileProcessedDirectory = "TransferControl_InboundFileProcessedDirectory";
        
        public const string TransferControlFtpEnable = "TransferControl_Ftp_Enable";
        public const string TransferControlFtpManhattanServer = "TransferControl_Ftp_ManhattanServer";
        public const string TransferControlFtpUserName = "TransferControl_Ftp_UserName";
        public const string TransferControlFtpPassword = "TransferControl_Ftp_Password";
        
        public const string TransferControlOutboundFileDirectory = "TransferControl_OutboundFileDirectory";
        public const string TransferControlOutboundFileProcessedDirectory = "TransferControl_OutboundFileProcessedDirectory";
        public const string TransferControlOutboundMasterControlFileName = "TransferControl_OutboundMasterControlFileName";

        public const string WarehouseAddressCity = "WarehouseAddress_City";
        public const string WarehouseAddressLine1 = "WarehouseAddress_Line1";
        public const string WarehouseAddressState = "WarehouseAddress_State";
        public const string WarehouseAddressZipCode = "WarehouseAddress_ZipCode";
        public const string WarehouseAddressCountry = "WarehouseAddress_Country";

        public const string PhoneNumber = "PhoneNumber";
        public const string UpsAccountNumber = "UpsAccountNumber";
    }
}

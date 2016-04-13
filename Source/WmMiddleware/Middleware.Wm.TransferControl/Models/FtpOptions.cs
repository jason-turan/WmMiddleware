using System.Net;

namespace Middleware.Wm.TransferControl.Models
{
    public class FtpOptions
    {
        private string _host;

        public string Host
        {
            get
            {
                return _host;
            }
            set
            {
                if (value.ToLower().StartsWith("ftp://"))
                {
                    _host = value;
                }
                else
                {
                    _host = "ftp://" + value;
                }
            }
        }

        public string UserId{ get; set; }
        
        public string Password { get; set; } 
        
        public IWebProxy Proxy { get; set; } 
        
        public bool EnableSsl { get; set; }
        
        public bool UseBinary { get; set; }
        
        public bool UsePassive { get; set; }
    }
}

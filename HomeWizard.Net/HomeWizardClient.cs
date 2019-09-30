using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    //Reference:
    //- https://github.com/depl0y/HCP/wiki/HomeWizard-API-Calls
    //- http://wiki.td-er.nl/index.php?title=Homewizard
    //- https://github.com/rvdvoorde/class.homewizard.php/blob/master/class.homewizard.php
    //- https://github.com/manuelvanrijn/homewizard-api/blob/master/homewizard-api.rb

    //Missing calls:
    //- wea/get Location?
    //Somfy

    public class HomeWizardClient : HomeWizardClientBase, IHomeWizardClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _ipAddress;
        private readonly string _password;
        /// <summary>
        /// Connect to a HomeWizard
        /// </summary>
        /// <param name="ipAddress">The IP address of the HomeWizard</param>
        /// <param name="password">The password of the HomeWizard</param>
        public HomeWizardClient(string ipAddress, string password) : base()
        {
            _ipAddress = ipAddress;
            _password = password;
        }
        public override bool IsLocal => true;
        
        protected override async Task<string> GetData(string command)
        {
            string url = Constants.BaseUrl.Replace("{password}", _password);
            if ("handshake".Equals(command, StringComparison.OrdinalIgnoreCase))
            {
                url = Constants.HandshakeUrl;
            }
            url = url.Replace("{ipAddress}", _ipAddress).Replace("{command}", command);

            try
            {
                return await DoRequest(url);
            }
            catch (Exception e)
            {
                throw new HomeWizardClientException("Error sending request to HomeWizard", e);
            }
        }
    }
}

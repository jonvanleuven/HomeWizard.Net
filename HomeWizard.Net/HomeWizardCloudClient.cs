using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class HomeWizardCloudClient : HomeWizardClientBase, IHomeWizardClient
    {
        private readonly string sessionKey;
        private readonly string serial;
        public HomeWizardCloudClient(string sessionKey, string serial) : base()
        {
            this.sessionKey = sessionKey;
            this.serial = serial;
        }

        public override bool IsLocal => false;

        /// <summary>
        /// Discover a HomeWizard on the local network
        /// </summary>
        /// <returns>Object containing the IP address. If no HomeWizard was found, the IP address is empty</returns>
        public static async Task<Discovery> Discover()
        {
            var data = await DoRequest(Constants.DiscoveryUrl, new HttpClient {Timeout = TimeSpan.FromSeconds(30)});
            return JsonConvert.DeserializeObject<Discovery>(data);
        }

        public static Login Login(string username, string password, string name = null)
        {
            var url = $"{Constants.CloudUrl}/account/login/?username={username}&password={password}";
            using (var response = new HttpClient { Timeout = TimeSpan.FromSeconds(30) }.GetAsync(url).Result)
            {
                response.EnsureSuccessStatusCode();
                var data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Login>(data);
                if (result.Status == "failed")
                    throw new InvalidSession(data);
                return result;
            }
        }

        protected override async Task<string> GetData(string command)
        {
            try
            {
                return await DoRequest($"https://cloud.homewizard.com/forward/{sessionKey}/{serial}/{command}");
            }
            catch (Exception e)
            {
                throw new HomeWizardClientException("Error sending request to HomeWizard", e);
            }
        }
    }

    
    public class InvalidSession : Exception
    {
        public InvalidSession(string m) : base(m)
        {
        }
    }
}

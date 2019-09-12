using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class HomeWizardCloudClient : HomeWizardClient, IHomeWizardClient
    {
        private readonly string sessionKey;
        private readonly string serial;
        public HomeWizardCloudClient(string sessionKey, string serial)
        {
            this.sessionKey = sessionKey;
            this.serial = serial;
        }

        public bool IsLocal => false;

        public static Login Login(string username, string password, string name = null)
        {
            var url = $"https://cloud.homewizard.com/account/login/?username={username}&password={password}";
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

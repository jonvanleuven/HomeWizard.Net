using System.Linq;

namespace HomeWizard.Net
{
    public static class HomeWizardClientFactory
    {
        public static IHomeWizardClient Create(string username, string passwordLocal, string passwordCloud, string name = null)
        {
            var discover = HomeWizardCloudClient.Discover().Result;
            if (string.IsNullOrEmpty(discover.Ip))
                return CreateCloud(username, passwordCloud, name);
            return CreateLocal(discover.Ip, passwordLocal);
        }

        public static IHomeWizardClient CreateLocal(string ip, string passwordLocal)
        {       
            return new HomeWizardClient(ip, passwordLocal);
        }

        public static IHomeWizardClient CreateCloud(string username, string passwordCloud, string name = null)
        {       
            var login = HomeWizardCloudClient.Login(username, passwordCloud);
            var response = login.Response.First(r => r.Name == name || name == null);
            return new HomeWizardCloudClient(login.Session, response.Serial); 
        }
        
    }
}

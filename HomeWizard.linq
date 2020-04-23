<Query Kind="Program">
  <Reference Relative="HomeWizard.Net\bin\Debug\net46\HomeWizard.Net.dll">C:\dev\HomeWizard.Net\HomeWizard.Net\bin\Debug\net46\HomeWizard.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Json.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>HomeWizard.Net</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//TODO: 
	// - SonosExtensions: eenvoudig virtual ip switch aanmaken/aanpassen
	// - setters van models private maken
	// - meer api calls: LockX, radiatorknoppen.... etc
	// - notification receiver toevoegen en afvangen (webserver)
	// - Homekit integratie?

	//var c = new HomeWizardClient();
	//var c = HomeWizardClientFactory.Create(Util.GetPassword("HomewizardUsername", false), Util.GetPassword("Homewizard", false), Util.GetPassword("HomewizardOnline", false));
	var login = HomeWizardCloudClient.Login(Util.GetPassword("HomewizardUsername", false), Util.GetPassword("HomewizardOnline", false));
	var c = new HomeWizardCloudClientWithLogging(login.Session, login.Response.First().Serial) as IHomeWizardClient;
	//c.AddSwitch("Zolder overl", SwitchType.Switch, "01EF696E09").Wait();
	//return;
	//c.GetSensors().Result.Dump();
	
	
	//c.GetSw
	//c.SwitchOn("000094A501").Wait();
	//return;
	//c.GetSwitches().Dump();
	//c.DimSwitch(1, 1).Dump();
	//c.SwitchOn(11);
	c.HueSwitch(11, 0, 100, 100).Wait();
	//c.GetScenes().Result.Dump();
	return;
	
	string current = null;
	foreach (var d in Poller(TimeSpan.FromMinutes(1)))
	{
		try
		{
			var sensors = c.GetSensors().Result;
			if( sensors == null ) {
				c = HomeWizardClientFactory.Create(Util.GetPassword("HomewizardUsername", false), Util.GetPassword("Homewizard", false), Util.GetPassword("HomewizardOnline", false));
				continue;
			}
			var log = $"{((Preset)sensors.Preset)}: temp {c.GetThermoMeters().Result.Skip(1).First().Temperature}ºC";
			if (current != log)
				Console.WriteLine($"{DateTime.Now:HH:mm:ss} {log}");
			current = log;
		}
		catch (Exception e)
		{
			e.Dump();
			Console.WriteLine($"{DateTime.Now:HH:mm:ss} ERROR: {e.Message}");
		}
	}
	
	c.IsLocal.Dump();
	c.GetSensors().Result.KakuSensors.OrderByDescending(k => k.TimeStamp).Dump();
	//c.GetKaKuSensorLogs(0).Result.Dump();
	//c.GetSwitches().Result.Dump();
	return;
	//c.GetSwitches().Result.Select(r => r.GetType()).Dump();
	//return;
	//c.GetStatus().Result.Dump();
	//c.GetNotificationReceivers().Result.Dump();
	//c.GetGraphMonths(0).Dump();
	//c.GetGraphTemperatureMonth(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.TeMin).AddYSeries(r => r.TeMax).DumpInline();
	//c.GetGraphTemperatureYear(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.TeMin).AddYSeries(r => r.TeMax).DumpInline();
	//return;
	
	c.GetGraphEneryLinkDay(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.A).DumpInline();
	c.GetGraphEneryLinkWeek(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.A).DumpInline();
	c.GetGraphEneryLinkMonth(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.A).DumpInline();
	c.GetGraphEneryLinkYear(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.G).DumpInline();
	c.GetGraphEneryLinkDay(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.G).DumpInline();
	c.GetGraphEneryLinkWeek(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.G).DumpInline();
	c.GetGraphEneryLinkMonth(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.G).DumpInline();
	c.GetGraphEneryLinkYear(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.G).DumpInline();
	c.GetGraphTemperatureDay(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.Te).DumpInline();
	c.GetGraphTemperatureWeek(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.Te).DumpInline();
	c.GetGraphTemperatureMonth(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.TeMin).AddYSeries(r => r.TeMax).DumpInline();
	c.GetGraphTemperatureYear(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.TeMin).AddYSeries(r => r.TeMax).DumpInline();
	c.GetGraphTemperatureDay(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.Hu).DumpInline();
	c.GetGraphTemperatureWeek(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.Hu).DumpInline();
	c.GetGraphTemperatureMonth(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.HuMin).AddYSeries(r => r.HuMax).DumpInline();
	c.GetGraphTemperatureYear(0).Result.Dump().Chart(r => r.T).AddYSeries(r => r.HuMin).AddYSeries(r => r.HuMax).DumpInline();
	return;
	c.GetEnergyMeters().Result.Dump("GetEnergyMeters");
	c.GetKaKuSensorLogs(0).Result.Dump("GetKaKuSensorLogs");
	c.GetRainMeters().Result.Dump("GetRainMeters");
	c.GetScenes().Result.Dump("GetScenes");
	c.GetSensors().Result.Dump("GetSensors");
	c.GetStatus().Result.Dump("GetStatus");
	c.GetSunTimesForToday().Result.Dump("GetSunTimesForToday");
	c.GetSunTimesForWeek().Result.Dump("GetSunTimesForWeek");
	c.GetSwitchCodes(0).Result.Dump("GetSwitchCodes");
	c.GetThermoMeters().Result.Dump("GetThermoMeters");
	//c.GetTriggers().Result.Dump("GetTriggers");
	c.GetUvMeters().Result.Dump("GetUvMeters");
	c.GetWindMeters().Result.Dump("GetWindMeters");
	
	return;



	//c.GetHandshake().Dump();
	//return;
	//var hw = c.Discover().Result.Dump();
	
	//c.Connect(hw.Ip, Util.GetPassword("Homewizard", false));
	c.GetSwitches().Dump();
	//c.GetSensors().Result.ThermoMeters.Dump();
	//c.GetThermoMeters().Dump();
	c.GetStatus().Result.Switches.Dump();
	
	//c.GetSunTimesForToday().Result.Sunrise
	//return;
	c.GetSensors().Result.EnergyLinks.First().Dump();
	
	c.GetThermoMeters().Dump();
	c.GetScenes().Dump();
	//c.SceneOn(0);
	c.GetSwitches().Dump();
	c.GetStatus().Dump();
}



public static IEnumerable<DateTime> Poller(TimeSpan t)
{
	yield return DateTime.Now;
	while (true)
	{
		Thread.Sleep((int)t.TotalMilliseconds);
		yield return DateTime.Now;
	}
}
public class HomeWizardCloudClientWithLogging : HomeWizardCloudClient
{
	public HomeWizardCloudClientWithLogging(string sessionKey, string serial) : base(sessionKey, serial)
	{
	}


	protected override async Task<string> DoRequest(string url)
	{
		//try all lists met 2 letters:
		/*var alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
		foreach (var a in alphabet)
		{
			foreach (var b in alphabet)
			{
				var turl = url.Replace("/gplist", $"/{a}{b}list");
				try
				{
					Console.WriteLine("try: " + turl);
					using (HttpResponseMessage response = await new HttpClient().GetAsync(turl))
					{
						response.EnsureSuccessStatusCode();
						Console.WriteLine("validurl: "+ turl);
						response.Content.ReadAsStringAsync().Result.Dump(turl);
					}

				}
				catch (Exception e)
				{

				}


			}

		}
		*/
		//url = url.Replace("/gplist", $"/tasks");
		//url = url.Replace("/sw/dim/1/1", $"/sw/11/on/0/200/100");
		
		using (HttpResponseMessage response = await new HttpClient().GetAsync(url))
		{
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync().Dump(url);
		}
	}
}

// Define other methods and classes here
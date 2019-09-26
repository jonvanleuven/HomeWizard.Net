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

	//var s = Util.GetPassword("HomeWizardOnlineSessionId").Split(',').Select(e => e.Split(':').Select(x => x.Replace("\"", "").Replace("}]", "")).ToArray()).Dump();
	//return;

	//var c = new HomeWizardClient();
	var c = HomeWizardClientFactory.Create(Util.GetPassword("HomewizardUsername", false), Util.GetPassword("Homewizard", false), Util.GetPassword("HomewizardOnline", false));
	c.GetSensors().Result.KakuSensors.Dump();
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

// Define other methods and classes here
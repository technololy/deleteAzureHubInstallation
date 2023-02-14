using System.Net.Http.Json;

namespace deleteAzureHubInstallation;
class Program
{
    static HttpClient httpClient;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("ss", "ss");
        GetInstallations(httpClient);

    }

    private static async void GetInstallations(HttpClient httpClient)
    {
        var result =  httpClient.GetFromJsonAsync<List<Pushnotif>>("https://pushnoticationapi.azurewebsites.net/api/Notifications/GetAllRegisteredDevices").Result;
        for (int i = 0; i < result?.Count; i++)
        {
            Pushnotif? item = result[i];
            var installationId = item.Tags[0];
            int pFrom = installationId.IndexOf("{")+1;
            int pTo = installationId.LastIndexOf("}");

            String result2 = installationId.Substring(pFrom, pTo - pFrom);
            //Delete(result2);
            PushNot(result2,item.Tags?[1]??"");
           
        }
    }

    private static void Delete(string result2)
    {
         var url = $"https://pushnoticationapi.azurewebsites.net/api/Notifications/installations/{result2}";
            Console.WriteLine(url);
            var response = httpClient.DeleteAsync(url).Result;
    }

       private static void PushNot(string value1, string value2)
    {
        Pushmodel push = new Pushmodel(){
Text = "Testing on "+DateTime.Now.ToLongDateString(),
Action="Do nothing",
Tags = new List<string>(){value1,value2}
        };
         var url = $"https://pushnoticationapi.azurewebsites.net/api/Notifications/requests";
            Console.WriteLine(url);
            var response = httpClient.PostAsJsonAsync<Pushmodel>(url,push).Result;
    }
}


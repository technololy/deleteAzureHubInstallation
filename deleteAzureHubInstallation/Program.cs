using System.Net.Http.Json;

namespace deleteAzureHubInstallation;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("ss", "ss");
        DeleteInstallations(httpClient);

    }

    private static async void DeleteInstallations(HttpClient httpClient)
    {
        var result =  httpClient.GetFromJsonAsync<List<Pushnotif>>("https://pushnoticationapi.azurewebsites.net/api/Notifications/GetAllRegisteredDevices").Result;
        for (int i = 0; i < result?.Count; i++)
        {
            Pushnotif? item = result[i];
            var installationId = item.Tags[0];
            int pFrom = installationId.IndexOf("{")+1;
            int pTo = installationId.LastIndexOf("}");

            String result2 = installationId.Substring(pFrom, pTo - pFrom);
            var url = $"https://pushnoticationapi.azurewebsites.net/api/Notifications/installations/{result2}";
            Console.WriteLine(url);
            var response = httpClient.DeleteAsync(url).Result;
        }
    }
}


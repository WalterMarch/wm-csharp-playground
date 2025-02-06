using System.Net.Http.Headers;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json")
);

await ProcessRepositoriesAsync(client);

// https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.GetStringAsync("https://ok.surf/api/v1/news-section-names");
    Console.Write(json);
}
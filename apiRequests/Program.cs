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
    var rawSectionNameString = await client.GetStringAsync("https://ok.surf/api/v1/news-section-names");
    var sectionNameString = rawSectionNameString.Substring(1, rawSectionNameString.Length - 3);    
    List<string> sectionNameList = sectionNameString.Split(',').ToList();   
    List<string> cleanedSectionNameList = new List<string>();

    foreach (string str in sectionNameList)
    {
        cleanedSectionNameList.Add(str.Replace("\"", ""));
    }
    
    Random random = new Random();
    int index = random.Next(cleanedSectionNameList.Count);
    string randomSection = cleanedSectionNameList[index];

    Console.WriteLine(randomSection);
}
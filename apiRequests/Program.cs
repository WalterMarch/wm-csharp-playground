using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json")
);

string sectionResult = await ProcessRepositoriesAsync(client);

List<string> sectionList = new List<string>
{
    sectionResult
};

NewsBodyObject newsBodyObject = new NewsBodyObject
{
    sections = sectionList
};

NewsRequest newsRequest = new NewsRequest
{
    NewsUrl = "https://ok.surf/api/v1/news-section",
    NewsMethod = "POST",
    NewsBody = newsBodyObject,
};

Console.WriteLine(JsonSerializer.Serialize(newsRequest));

// https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient

static async Task<string> ProcessRepositoriesAsync(HttpClient client)
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

    return randomSection;
}

public class NewsRequest
{
    public string? NewsUrl { get; set; }
    public string? NewsMethod { get; set; }
    public NewsBodyObject? NewsBody { get; set; }
}

public class NewsBodyObject
{
    public List<string>? sections { get; set; }
}
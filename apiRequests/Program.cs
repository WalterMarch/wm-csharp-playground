using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json")
);

string sectionResult = await ProcessRepositoriesAsync(client);

string newsBody = "{\"sections\":[\"" + sectionResult + "\"]}";

HttpContent content = new StringContent(newsBody, Encoding.UTF8, "application/json");
HttpResponseMessage response = await client.PostAsync("https://ok.surf/api/v1/news-section", content);

string responseString = await response.Content.ReadAsStringAsync();
dynamic responseJson = JsonConvert.DeserializeObject(responseString);

Console.WriteLine(responseJson);

static async Task<string> ProcessRepositoriesAsync(HttpClient client)
{
    string rawSectionNameString = await client.GetStringAsync("https://ok.surf/api/v1/news-section-names");
    string sectionNameString = rawSectionNameString.Substring(1, rawSectionNameString.Length - 3);    
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

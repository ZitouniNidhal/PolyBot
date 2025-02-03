using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class OpenAIService
{
    private readonly HttpClient _httpClient;

    public OpenAIService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer VOTRE_CLE_API");
    }

    public async Task<string> GenerateText(string prompt)
    {
        var request = new
        {
            model = "text-davinci-003",
            prompt = prompt,
            max_tokens = 150,
            temperature = 0.7
        };

        var content = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);
        var responseBody = await response.Content.ReadAsStringAsync();

        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
        return data.choices[0].text;
    }
}
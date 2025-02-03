public class LanguageModelService
{
    private readonly HttpClient _httpClient;

    public LanguageModelService(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> GenerateResponseAsync(string prompt)
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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class TranslationService
{
    private readonly HttpClient _httpClient;

    public TranslationService(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> TranslateTextAsync(string text, string targetLanguage)
    {
        var request = new
        {
            text = text,
            target_language = targetLanguage
        };

        var content = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("https://api.translation-service.com/translate", content);
        var responseBody = await response.Content.ReadAsStringAsync();

        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
        return data.translated_text;
    }
}
//Il indique clairement que cette classe est responsable de la traduction de texte.
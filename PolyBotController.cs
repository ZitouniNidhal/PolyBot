using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PolyBotController : ControllerBase
{
    private readonly PolyBotDbContext _dbContext;
    private readonly LanguageModelService _languageModelService;

    public PolyBotController(PolyBotDbContext dbContext, string openAiApiKey)
    {
        _dbContext = dbContext;
        _languageModelService = new LanguageModelService(openAiApiKey);
    }

    [HttpPost("ask")]
    public async Task<IActionResult> AskQuestion([FromBody] string userInput)
    {
        // Vérifier si la question existe déjà dans la base de données
        var faq = _dbContext.FAQs.FirstOrDefault(f => f.Question == userInput);

        if (faq != null)
        {
            // Réponse depuis la base de données
            return Ok(new { Response = faq.Answer });
        }

        // Sinon, générer une réponse via le modèle linguistique
        var llmResponse = await _languageModelService.GenerateResponseAsync(userInput);

        // Enregistrer la conversation dans la base de données
        _dbContext.Conversations.Add(new Conversation
        {
            UserInput = userInput,
            BotResponse = llmResponse,
            Timestamp = DateTime.UtcNow
        });
        await _dbContext.SaveChangesAsync();

        return Ok(new { Response = llmResponse });
    }
}

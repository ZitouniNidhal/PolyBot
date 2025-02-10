namespace PolyBotApi
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // Échelle de 1 à 5
        public DateTime Timestamp { get; set; }
    }
    //Il représente les retours des utilisateurs sur l'assistant
}
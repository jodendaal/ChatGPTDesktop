namespace ChatGPTDesktop.Models
{
    public class ActPrompt
    {
        public ActPrompt() 
        { 
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; init; }
        public string Act { get; init; }
        public string Prompt { get; init; }
    }
}

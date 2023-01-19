namespace ChatGPTDesktop.Models
{

    public abstract class BaseEntity
    {
        public abstract string Id();
        
    }

    public class ActPrompt : BaseEntity
    {
        public string Act { get; init; }
        public string Prompt { get; init; }

        public override string Id()
        {
            return Act;
        }
    }
}

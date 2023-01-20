using ChatGPTDesktop.Models;

namespace ChatGPTDesktop.Services
{

    public class AwsomePromptsRespository : BaseRepository<AwsomePromptsRespository, ActPrompt>, IAwsomePromptsRespository
    {
        public AwsomePromptsRespository():base("Act")
        {

        }
    }
}

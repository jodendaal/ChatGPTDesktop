using ChatGPTDesktop.Models;

namespace ChatGPTDesktop.Services
{
    public class MyPromptsRespository : BaseRepository<MyPromptsRespository, ActPrompt>, IMyPromptsRespository
    {
        public MyPromptsRespository() : base("Act")
        {

        }
    }
}

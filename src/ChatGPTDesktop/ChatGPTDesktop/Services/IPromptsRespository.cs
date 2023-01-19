using ChatGPTDesktop.Models;

namespace ChatGPTDesktop.Services
{
    public interface IPromptsRespository : IBaseRepository<ActPrompt>
    {
       
    }

    public class PromptsRespository : BaseRepository<PromptsRespository,ActPrompt>, IPromptsRespository
    {
        public PromptsRespository():base("Act")
        {

        }
    }
}

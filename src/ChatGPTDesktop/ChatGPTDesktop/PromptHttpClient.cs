using ChatGPTDesktop.Models;

namespace ChatGPTDesktop
{
    public class PromptHttpClient
    {
        private readonly HttpClient _httpClient;

        public PromptHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ActPrompt>> GetPrompts()
        {
            var response = await _httpClient.GetAsync("https://raw.githubusercontent.com/f/awesome-chatgpt-prompts/main/prompts.csv");
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStringAsync();
                return ParseCSV(stream);
            }

            return new List<ActPrompt>();
        }

        private List<ActPrompt> ParseCSV(string data)
        {
            var list = new List<ActPrompt>();

            var lines = data.Split("\n").ToList();
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var act = line.Substring(0, line.IndexOf(','));
                    var prompt = line.Substring(line.IndexOf(',') + 1, (line.Length - (line.IndexOf(',') + 1)));

                    act = act.Remove(0, 1);
                    act = act.Remove(act.Length - 1, 1);

                    prompt = prompt.Remove(0, prompt.IndexOf(@""""));
                    prompt = prompt.Remove(prompt.Length - 1, 1);

                    list.Add(new ActPrompt()
                    {
                        Act = act,
                        Prompt = prompt
                    });
                }
            }

            return list;

        }
    }
}

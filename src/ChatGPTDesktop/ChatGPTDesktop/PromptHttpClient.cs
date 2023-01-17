using ChatGPTDesktop.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace ChatGPTDesktop
{
    internal class PromptHttpClient
    {
        public PromptHttpClient()
        {

        }


        public async Task<List<ActPrompt>> GetPrompts()
        {
            using (HttpClient client = new HttpClient())
            {

                var response = await client.GetAsync("https://raw.githubusercontent.com/f/awesome-chatgpt-prompts/main/prompts.csv");
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStringAsync();
                    return ParseCSV(stream);
                    //var stream = await response.Content.ReadAsStreamAsync();
                    //return ParseCSV(stream);
                }
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
                    try
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
                    catch(Exception ex) { 
                    
                    }
                    }
            }

                return list;

        }

        private List<ActPrompt> ParseCSV(Stream stream)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
              HasHeaderRecord = false,
              BadDataFound = null
            };

            using (var reader = new StreamReader(stream))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    return csv.GetRecords<ActPrompt>().ToList();
                }
            }

        }
    }
}

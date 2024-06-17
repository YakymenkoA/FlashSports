using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FlashSportsLib.Models;
using Newtonsoft.Json.Linq;


namespace FlashSportsLib.Services
{
    public class ApiManager
    {
        private static readonly HttpClient client = new HttpClient();

        public List<SportEvent> AlexSportTypeGetInfo()
        {
            var list = new List<SportEvent>();
            return list;
        }

        public async Task<List<SportEvent>> CricketGetInfo()
        {
            var list = new List<SportEvent>();
            Random random = new Random();

            const string API_URL = "https://api.cricapi.com/v1/matches?apikey=f78d5665-6fc7-47e6-8e75-176acfc62878&offset=0";

            try
            {
                HttpResponseMessage response = await client.GetAsync(API_URL);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    JObject responseJson = JObject.Parse(jsonData);

                    JArray events = (JArray)responseJson["data"];

                    foreach (var e in events)
                    {
                        string y = "2024";
                        int m = random.Next(7, 10);
                        int d = random.Next(1, 31);

                        string mT = m.ToString();
                        string dT = d.ToString();

                        string name = (string)e["name"];
                        string description = "Some description";
                        string dateStr = $"{d}.{m}.{y}";

                        DateTime date = DateTime.Parse(dateStr);

                        list.Add(new SportEvent()
                        {
                            Id = 0,
                            Title = name,
                            Description = description,
                            IssueDate = date,
                            CategoryId = 2
                        });
                    }
                    return list;
                }
                else { return null; }
            }
            catch (Exception) { return null; }
        }

        public List<SportEvent> SoccerGetInfo()
        {
            var list = new List<SportEvent>();

            const string API = "f4781d7f5cca4ecb8ca5ae4a28c6ad00";
            const string URL = "https://replay.sportsdata.io/api/v4/soccer/odds/json/activesportsbooks?key=f4781d7f5cca4ecb8ca5ae4a28c6ad00";

            WebClient webClient = new WebClient();
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", API);
            try
            {
                string jsonData = webClient.DownloadString(URL);

                JArray events = JArray.Parse(jsonData);
                // ->
                foreach (var e in events)
                {
                    string title = (string)e["Name"];
                    string description = "No description available!";
                    var date = DateTime.Now;
                    // ->
                    list.Add(new SportEvent()
                    {
                        Id = 0,
                        Title = title,
                        Description = description,
                        IssueDate = date,
                        CategoryId = 3
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // ->
            return list;
        }

        public List<SportEvent> IllyaSportTypeGetInfo()
        {
            var list = new List<SportEvent>();
            return list;
        }
    }
}

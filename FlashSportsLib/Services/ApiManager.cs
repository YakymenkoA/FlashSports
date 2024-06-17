using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FlashSportsLib.Models;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace FlashSportsLib.Services
{
    public class ApiManager
    {
        public async Task<List<SportEvent>> GolfGetInfoAsync()
        {
            var list = new List<SportEvent>();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var options = new RestClientOptions("https://api.sportradar.com/golf/trial/pga/v3/en/2023/01/04/changes.xml?api_key=P5akdViWfW6DWFaifLunA2RLZvylY9wL2oUGVjEB");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/xml");
            var response = await client.GetAsync(request);

            var xmlData = XDocument.Parse(response.Content);
            XNamespace ns = "http://feed.elasticstats.com/schema/golf/changelog-v1.0.xsd";
            var tournaments = xmlData.Descendants(ns + "tournaments").FirstOrDefault();

            int i = 1;
            foreach (var name in tournaments.Elements().Attributes("name"))
            {
                list.Add(new SportEvent()
                {
                    Id = 0,
                    Title = name.Value,
                    Description = $"Event #{i} description",
                    IssueDate = DateTime.Now.AddDays(i),
                    CategoryId = 1
                });
                i++;
            }
            return list;
        }

        public async Task<List<SportEvent>> CricketGetInfo()
        {
            var list = new List<SportEvent>();
            Random random = new Random();
            HttpClient client = new HttpClient();

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

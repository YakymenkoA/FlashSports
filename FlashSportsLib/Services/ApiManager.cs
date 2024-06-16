using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FlashSportsLib.Models;
using Newtonsoft.Json.Linq;


namespace FlashSportsLib.Services
{
    public class ApiManager
    {
        public List<SportEvent> AlexSportTypeGetInfo()
        {
            var list = new List<SportEvent>();
            return list;
        }

        public List<SportEvent> MaxSportTypeGetInfo()
        {
            var list = new List<SportEvent>();
            return list;
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

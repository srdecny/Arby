using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using Arby.dataclass;
using Arby.util;
using Newtonsoft.Json;

namespace Arby
{
    public class MatchbookController
    {
        private HttpClient Client = new HttpClient();
        public MatchbookModel Model { get; set; }
        public ArbyForm Form { get; set; } // So we can change the display controls inside the form with new data

        

        // Logs in into Matchboook using Credentials in Model.
        public async Task LogIn()
        {
            try
            {
                string LoginCredentials = JsonConvert.SerializeObject(Model.Credentials);
                var response = await GeneratePostRequest("bpapi/rest/security/session", LoginCredentials);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Model.Session = JsonConvert.DeserializeObject<Session>(responseContent);
                    Client.DefaultRequestHeaders.Add("session-token", Model.Session.SessionToken);
                    Form.EnqueueUpdateAction(Form.UpdateLoginBox);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    GUIHelper.ThrowWarning("Login error", "Login failed - invalid username or password.");
                }
                else
                {
                    GUIHelper.ThrowWarning("Unknown error",
                        "Login failed. Error code returned: " + response.StatusCode.ToString());
                }
            }
            catch (HttpRequestException ex)
            {
                GUIHelper.ThrowWarning("Web error", "Error accessing Matchbook. Check internet connection and/or Matchbook status.");
            }

        }

        // Generates new Post request to given API path with given payload and returns the response
        public async Task<HttpResponseMessage> GeneratePostRequest(string RelativePath, string JsonPayload)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, RelativePath);
            request.Content = new StringContent(JsonPayload, Encoding.UTF8, "application/json");
            request.Content.Headers.Add("accept-type", "appliation/json");
            return await Client.SendAsync(request);
        }

        // Generates new Get request to given API path with given payload and returns the response
        public async Task<String> GenerateGetRequest(string RelativePath)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, RelativePath);
                var response = await Client.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                GUIHelper.ThrowWarning("Web error", "Error accessing Matchbook. Check internet connection and/or Matchbook status.");
                return "";
            }
        }

        public async Task GetPopularMarkets()
        {
            var response = await GenerateGetRequest("edge/rest/popular-markets");
            var info = JsonConvert.DeserializeObject<EventInfo>(response);
            Model.PopularEvents = info;
            Form.EnqueueUpdateAction(Form.UpdateEventsBox);
        }

        public MatchbookController()
        {
            Client.BaseAddress = new Uri("https://api.matchbook.com/");
        }

        public async Task GetEventPrices(long EventID)
        {
            var response = await GenerateGetRequest($"edge/rest/events/{EventID}");
            Model.EventPrices.Add(EventID, JsonConvert.DeserializeObject<Event>(response));
            Form.EnqueueUpdateAction(Form.UpdateEventDetailsBox);
        }

        public async Task ScrapeEvent(long EventID)
        {
            var Response = await GenerateGetRequest($"edge/rest/events/{EventID}");
            var Event = JsonConvert.DeserializeObject<Event>(Response);
            List<MarketSnapshot> Snapshots = MatchbookSnapshotConverter.ConvertEventToSnapshot(Event);
            lock (Model.MarketSnapshots)
            {
                if (!(Model.MarketSnapshots.ContainsKey(EventID))) Model.MarketSnapshots.Add(EventID, new List<MarketSnapshot>());
                Model.MarketSnapshots[EventID] = Model.MarketSnapshots[EventID].Concat(Snapshots).ToList();
            }
        }
    }
}

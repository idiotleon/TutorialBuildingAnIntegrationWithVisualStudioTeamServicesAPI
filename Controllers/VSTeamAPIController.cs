using System;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;

namespace TutorialVSTSAPI1.Controllers
{
    public class VSTeamAPIController : Controller
    {
        // GET: BasicAuth
        [HttpGet]
        public ActionResult BasicAuth()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> BasicAuth(string username, string password, string account)
        {
            return View(viewName: "VSTSAPIResponse", model: await GetProjects(username, password, account));
        }

        private async Task<string> GetProjects(string username, string password, string account)
        {
            string responseBody = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
                    using (HttpResponseMessage response = client.GetAsync(
                        $"https://{account}.visualstudio.com/DefaultCollection/_apis/api-version=1.0").Result)
                    {
                        response.EnsureSuccessStatusCode();
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                responseBody = $"{{\"Error\":\"{ex.Message}\"}}";
            }

            return responseBody;
        }
    }
}
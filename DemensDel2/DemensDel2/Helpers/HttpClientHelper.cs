using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DemensDel2.Models;

namespace DemensDel2.Helpers
{


    public class HttpClientHelper
    {
        public static async Task<object> HttpAPIRequest(string apiUrl)
        {
            object responseObject = new object();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(data);
                }
            }

            return responseObject;
        }
    }
}

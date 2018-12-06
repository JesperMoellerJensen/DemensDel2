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
        public static async Task<string> HttpAPIRequest(string apiUrl)
        {
            object responseObject = new object();
            string data = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                    responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(data);
                }
            }

            return data;
        }
    }
}

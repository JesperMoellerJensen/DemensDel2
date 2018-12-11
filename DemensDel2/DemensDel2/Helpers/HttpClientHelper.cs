using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DemensDel2.Models;
using Newtonsoft.Json;

namespace DemensDel2.Helpers
{


    public class HttpClientHelper
    {
        public static async Task<string> ApiGet(string apiUrl)
        {
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
                }
            }

            return data;
        }

        public static async void ApiPost(string apiUrl, object item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string jsonObject = JsonConvert.SerializeObject(item);
                var content = new StringContent(jsonObject);
                await client.PostAsync(apiUrl, content);
            }
        }
    }
}

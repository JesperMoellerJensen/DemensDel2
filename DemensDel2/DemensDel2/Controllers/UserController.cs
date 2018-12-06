using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DemensDel2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemensDel2.Controllers
{
    public class UserController : Controller
    {
        private string baseUrl = "http://localhost:55205/api/values";

        public async Task<IActionResult> Index()
        {
            User user = new User();
            string apiUrl = baseUrl + "/1";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
                }
            }
            return View(user);
        }


        //[HttpPost]
        //public IActionResult Bid(AuctionItem auctionItem)
        //{
        //    string message = "";
        //    Bid bid = new Bid()
        //    {
        //        ItemNumber = auctionItem.ItemNumber,
        //        CustomName = auctionItem.BidCustomName,
        //        CustomPhone = auctionItem.BidCustomPhone,
        //        Price = auctionItem.BidPrice
        //    };

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseUrl);

        //        //HTTP POST
        //        var postTask = client.PostAsJsonAsync<Bid>("auction", bid); //1 argument is name of api controller
        //        postTask.Wait();
        //        message = postTask.Result.StatusCode.ToString();
        //        var result = postTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
        //        {
        //            message = "Wrong info, try again";
        //        }
        //        else if (result.StatusCode == System.Net.HttpStatusCode.NotAcceptable)
        //        {
        //            message = "Bid to low";
        //        }
        //        else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
        //        {
        //            message = "Item not found";
        //        }
        //        else
        //        {
        //            message = "Error, try again";
        //        }

        //    }

        //    ModelState.AddModelError(string.Empty, "Something went wrong: " + message);

        //    return View();
        //}

    }
}
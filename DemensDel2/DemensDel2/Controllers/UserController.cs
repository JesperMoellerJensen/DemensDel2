﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DemensDel2.Helpers;
using DemensDel2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemensDel2.Controllers
{
    public class UserController : Controller
    {
        private HttpClientHelper _httpClientHelper;

        public UserController(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
            _httpClientHelper.baseUri = new Uri("http://localhost:55205/");
        }

        public IActionResult Index()
        {
            int id = 1;

            User user = _httpClientHelper.Get<User>("api/users/" + id + "");

            user.TrainingSessions = _httpClientHelper.Get<List<TrainingSession>>("api/TrainingSessions/user/" + id + "");
            //string baseUrl = "http://localhost:55205/api/users";
            //string APIUrl = $"{baseUrl}/{id}";

            //string response = await HttpClientHelper.ApiGet(APIUrl);
            //User user = JsonConvert.DeserializeObject<User>(response);

            //baseUrl = "http://localhost:55205/api/TrainingSessions/user";
            //APIUrl = $"{baseUrl}/{id}";
            //response = await HttpClientHelper.ApiGet(APIUrl);

            //user.TrainingSessions = JsonConvert.DeserializeObject<List<TrainingSession>>(response);

            return View(user);

        }

        [HttpPost]
        public string CreateTrainingSession(DateTime date)
        {
            //string APIUrl = "http://localhost:55205/api/TrainingSessions";
            

            //TrainingSession trainingSession = new TrainingSession
            //{
            //    Date = date,
            //    User = new User
            //    {
            //        Id = 1
            //    }
            //};

            //HttpClientHelper.ApiPost(APIUrl,trainingSession);
            return "hej";
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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Exercise(int id)

        
        //[HttpGet("User/Exercise/{id}")]
        public IActionResult Exercise(int id)
        {
            List<Exercise> Exercises = new List<Exercise>()
            {
                new Exercise()
                {
                    Id = 1,
                    PaintLevel = 23,
                    Effort = 21,
                    ExecutionRate = 21,
                    ExerciseType = new ExerciseType()
                    {
                        Name = "Arm løftning",
                        Duration = 20,
                        Difficulty = 4,
                        Description = "Løft begge arme",
                        MuscleGroup = "Arme"
                    }
                },
                new Exercise()
                {
                    Id = 2,
                    PaintLevel = 17,
                    Effort = 12,
                    ExecutionRate = 70,
                    ExerciseType = new ExerciseType()
                    {
                        Name = "Ben løftning",
                        Duration = 12,
                        Difficulty = 4,
                        Description = "Løft begge ben",
                        MuscleGroup = "Ben"
                    }
                }
            };

            Dictionary<int, string> eNames = new Dictionary<int, string>();
            foreach (Exercise e in Exercises)
            {
                eNames.Add(e.Id ,e.ExerciseType.Name);
            }
            ExerciseDTO exerciseDTO = new ExerciseDTO()
            {
                ExerciseNames = eNames
            };

            if (id != 0)
            {
                exerciseDTO.SlectedExercise = Exercises[id - 1];
            }
            else
            {
                exerciseDTO.SlectedExercise = null;
            }

            //string apiUrl = "http://localhost:55205/api/exercise" + "/" + id;

            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(apiUrl);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = await response.Content.ReadAsStringAsync();
            //        exercise = Newtonsoft.Json.JsonConvert.DeserializeObject<Exercise>(data);
            //    }
            //}
            return View(exerciseDTO);
        }

    }
}
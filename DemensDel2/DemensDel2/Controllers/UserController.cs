using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DemensDel2.Helpers;
using DemensDel2.Models;
using DemensDel2.Models.DTO;
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

            UserWithTrainingSessionDTO userDto = new UserWithTrainingSessionDTO
            {
                Name = user.Name,
                Address = user.Address,
                Age = user.Age,
                City = user.City,
                TelephoneNumber = user.TelephoneNumber,
                TrainingSessions = _httpClientHelper.Get<List<TrainingSession>>("api/TrainingSessions/user/" + id + "")
            };

            return View(userDto);
        }

        [HttpPost]
        public IActionResult Index(DateTime date)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError(string.Empty, "Data invalid");
            //    return View();
            //}
            //int id = 1;

            //User user = _httpClientHelper.Get<User>("api/users/" + id + "");

            //TrainingSession trainingSession = new TrainingSession
            //{
            //    Date = date,
            //    User = user
            //};


            //_httpClientHelper.Post<TrainingSession>(trainingSession, "TrainingSessions");
            return RedirectToAction("Index");
        }

        [HttpGet("User/TrainingSession/{tId}/{eId?}")]
        public IActionResult TrainingSession(int tId, int? eId = null)
        {
            List<Exercise> exercises = _httpClientHelper.Get<List<Exercise>>("api/exercises/trainingsession/" + tId + "");

            Dictionary<int, string> eNames = new Dictionary<int, string>();
            foreach (Exercise e in exercises)
            {
                eNames.Add(e.Id ,e.ExerciseType.Name);
            }
            ExerciseDTO exerciseDTO = new ExerciseDTO()
            {
                ExerciseNames = eNames
            };

            if (eId != null)
            {
                exerciseDTO.SlectedExercise = exercises.First(e => e.Id == eId);
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
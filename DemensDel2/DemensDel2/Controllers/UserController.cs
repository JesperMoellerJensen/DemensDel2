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
                exerciseDTO.ExerciseResult = _httpClientHelper.Get<ExerciseResult>("api/exerciseresults/" + exerciseDTO.SlectedExercise.Id);
            }
            else
            {
                exerciseDTO.SlectedExercise = null;
            }
            return View(exerciseDTO);
        }

    }
}
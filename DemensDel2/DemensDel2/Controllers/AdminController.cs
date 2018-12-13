using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemensDel2.Models.DTO;
using DemensDel2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemensDel2.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            NewTrainingSession newTrainingSession = new NewTrainingSession()
            {
                NewExercise = new NewExercise()
                {
                    ExerciseTypes = GetExerciseTypes()
                }
            };
           
            return View(newTrainingSession);
        }

       
        public ActionResult GetExercisePartialView(int exerciseNr)
        {
            NewExercise newExercise = new NewExercise() { ExerciseTypes = GetExerciseTypes(), ExerciseNr = exerciseNr };

            return PartialView("NewExercise", newExercise);//return your partial view here
        }

        private IList<SelectListItem> GetExerciseTypes()
        {
            return new List<SelectListItem>() {
                new SelectListItem {Text = "Løft Arme", Value = "1"},
                new SelectListItem {Text = "Løft Ben", Value = "2"}
            };
        }

        [HttpPost]
        public IActionResult CreateTrainingsession(NewTrainingSession trainingSession)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Data invalid");
                return View("Index");
            }

            return View("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageSchool;
using LanguageSchool.Command.Bookings;
using LanguageSchool.Entities;
using LanguageSchool.Query.Training;
using LanguageSchool.ValueObjects;
using LanguageSchool.UI.Models;

namespace LanguageSchool.UI.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{courseId}/{trainingId}")]
        public IActionResult Index(Guid courseId, Guid trainingId)
        {
            var trainingDetails = _mediator.Query(new GetTrainingQuery(courseId, trainingId));
            var model = new BuyBookingViewModel
            {
                CourseId =courseId,
                TrainingId = trainingId,
                TrainingDate = trainingDetails.TrainingDate,
                CourseName = trainingDetails.CourseName
            };

            return View(model);
        }

        [HttpPost("{courseId}/{trainingId}")]
        public IActionResult Index(Guid courseId, Guid trainingId, BuyBookingViewModel model)
        {
            var command = new BuyBookingCommand(new Id<Course>(courseId), model.TrainingDate, model.Email, model.Quantity);
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
                ModelState.PopulateValidation(result.Errors);
                return View(model);
            }

            return RedirectToAction("Index", "Course");
        }
    }
}
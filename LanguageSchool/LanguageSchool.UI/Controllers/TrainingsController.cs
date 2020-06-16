using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageSchool;
using LanguageSchool.Command.Trainings;
using LanguageSchool.Query.Courses;

namespace LanguageSchool.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class TrainingsController : Controller
    {
        private readonly IMediator _mediator;

        public TrainingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public IActionResult Index(Guid id)
        {
            var course = _mediator.Query(new GetCourseQuery(id));
            return View(course);
        }

        [HttpGet("{courseId}")]
        public IActionResult Add(Guid courseId)
        {
            var command = new RegisterTrainingCommand
            {
                CourseId = courseId,
                TrainingDate = DateTime.UtcNow
            };

            return View(command);
        }

        [HttpPost("{courseId}")]
        public IActionResult Add(Guid courseId, RegisterTrainingCommand command)
        {
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
                return View(command);
            }

            return RedirectToAction("Index", new { id = courseId });
        }
    }
}
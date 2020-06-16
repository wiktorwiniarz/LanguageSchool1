using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LanguageSchool;
using LanguageSchool.Command.Course;
using LanguageSchool.Query.Courses;

namespace LanguageSchool.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            var courses = _mediator.Query(new GetAllCoursesQuery());

            return View(courses);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCourseCommand command)
        {
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
               ModelState.PopulateValidation(result.Errors);
                return View(command);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var course = _mediator.Query(new GetCourseQuery(id));
            var model = new EditCourseCommand
            {
                Id = course.Id,
                Name = course.Name,
                Year = course.Year,
                TrainingTime = course.TrainingTime
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditCourseCommand command)
        {
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
                return View(command);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var result = _mediator.Command(new DeleteCourseCommand(id));
            if (result.IsSuccess == false)
            {
                ViewData["Error"] = result.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
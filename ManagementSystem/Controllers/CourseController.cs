using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace ManagementSystem.Controllers
{
	public class CourseController : Controller
	{
		private readonly IServiceManager _manager;

		public CourseController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Courses()
		{
			var courses = _manager.CourseService.GetAllCourses(false);
			return View(courses);
		}

		public IActionResult Detail(int id)
		{
			var course = _manager.CourseService.GetCourseById(id, false);
			return View(course);
		}

		public IActionResult Edit(int id)
		{
			// Course verisini al
			var course = _manager.CourseService.GetCourseById(id, true);

			// Instructor listesini al
			var instructors = _manager.InstructorService.GetAllInstructors(false);

			// ViewBag içine InstructorId ve isimleri aktar
			ViewBag.InstructorList = instructors.Select(i => new SelectListItem
			{
				Value = i.InstructorId.ToString(),
				Text = $"{i.FirstName} {i.LastName}"
			}).ToList();

			return View(course);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromForm] CourseDtoForUpdate course)
		{
			_manager.CourseService.UpdateOneCourse(course);

			return RedirectToAction("Courses");
		}

		public IActionResult Create()
		{
			// Instructor listesini al
			var instructors = _manager.InstructorService.GetAllInstructors(false);

			// ViewBag içine InstructorId ve isimleri aktar
			ViewBag.InstructorList = instructors.Select(i => new SelectListItem
			{
				Value = i.InstructorId.ToString(),
				Text = $"{i.FirstName} {i.LastName}"
			}).ToList();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] Course course)
		{
			if (ModelState.IsValid)
			{
				_manager.CourseService.CreateCourse(course);
				return RedirectToAction("Courses");
			}
			return View(course);
		}
	}
}
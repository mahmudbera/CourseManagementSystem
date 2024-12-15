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
			var course = _manager.CourseService.GetCourseById(id, true);
			var instructors = _manager.InstructorService.GetAllInstructors(false);

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
			if (ModelState.IsValid)
			{
				if (course.InstructorId is not null)
					course.Status = "Active";
				else
					course.Status = "Inactive";

				var (isSuccess, message) = _manager.CourseService.UpdateOneCourse(course);

				ViewBag.Message = message;
				ViewBag.Success = isSuccess;
			}
			else
			{
				ViewBag.Message = "Please correct the errors in the form.";
				ViewBag.Success = false;
			}

			return View("Courses", _manager.CourseService.GetAllCourses(false));
		}

		public IActionResult Create()
		{
			var instructors = _manager.InstructorService.GetAllInstructors(false);

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
				// Kursun durumunu belirle
				if (course.InstructorId is null)
					course.Status = "Inactive";
				else
					course.Status = "Active";

				var (isSuccess, message) = _manager.CourseService.CreateCourse(course);

				ViewBag.Message = message;
				ViewBag.Success = isSuccess;

				if (isSuccess)
					return View("Courses", _manager.CourseService.GetAllCourses(false));
				else
					return View();
			}
			else
			{
				ViewBag.Message = "Please correct the errors in the form.";
				ViewBag.Success = false;

				return View(course);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			var (isSuccess, message) = _manager.CourseService.DeleteCourse(id);

			ViewBag.Message = message;
			ViewBag.Success = isSuccess;

			// Mesajla birlikte aynı sayfaya yönlendirme
			return View("Courses", _manager.CourseService.GetAllCourses(false));
		}
	}
}
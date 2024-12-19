using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace ManagementSystem.Controllers
{
	public class EnrollmentController : Controller
	{
		private readonly IServiceManager _manager;

		public EnrollmentController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Enrollments(int? courseId = null)
		{
			var enrollments = _manager.EnrollmentService
				.GetAllEnrollments(false)
				.ToList();

			if (courseId.HasValue)
				enrollments = enrollments.Where(e => e.CourseId == courseId.Value).ToList();

			var activeStudents = _manager.StudentService
				.GetAllStudents(false)
				.Where(s => s.Status == "Active")
				.ToList();

			var activeCourses = _manager.CourseService
				.GetAllCourses(false)
				.Where(c => c.Status == "Active" && c.Classroom != null)
				.ToList();

			ViewBag.Students = activeStudents.Select(s => new SelectListItem
			{
				Value = s.StudentId.ToString(),
				Text = $"{s.FirstName} {s.LastName}"
			}).ToList();

			ViewBag.Courses = activeCourses.Select(c => new SelectListItem
			{
				Value = c.CourseId.ToString(),
				Text = c.CourseName
			}).ToList();

			var message = TempData["Message"];
			var success = TempData["Success"];

			if (message != null)
			{
				ViewBag.Message = message.ToString();
				ViewBag.Success = Convert.ToBoolean(success);
			}

			return View(enrollments);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] Enrollment enrollment)
		{
			if (ModelState.IsValid)
			{
				var (isSuccess, message) = _manager.EnrollmentService.AddEnrollment(enrollment);

				TempData["Message"] = message;
				TempData["Success"] = isSuccess;
			}
			return RedirectToAction("Enrollments");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromForm] EnrollmentDtoForGrade enrollmentDto)
		{
			if (ModelState.IsValid)
			{
				var (isSuccess, message) = _manager.EnrollmentService.UpdateOneEnrollmentGrade(enrollmentDto);

				TempData["Message"] = message;
				TempData["Success"] = isSuccess;
			}
			return RedirectToAction("Enrollments");
		}
	}
}
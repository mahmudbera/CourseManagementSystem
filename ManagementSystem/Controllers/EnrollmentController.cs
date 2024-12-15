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

		public IActionResult Enrollments()
		{
			var enrollments = _manager.EnrollmentService
				.GetAllEnrollments(false)
				.ToList();

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

			return View(enrollments);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] Enrollment enrollment)
		{
			if (ModelState.IsValid)
			{
				_manager.EnrollmentService.AddEnrollment(enrollment);
				Console.WriteLine($"\nSA StudentId: {enrollment.StudentId.GetType()}, CourseId: {enrollment.CourseId.GetType()}, Date: {enrollment.EnrollmentDate.GetType()}\n");
				return RedirectToAction("Enrollments");
			}
			return RedirectToAction("Enrollments");
		}
	
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromForm] EnrollmentDtoForGrade enrollmentDto)
		{
				Console.WriteLine($"\n {enrollmentDto.EnrollmentId} {enrollmentDto.Grade} {enrollmentDto.StudentId} {enrollmentDto.CourseId} {enrollmentDto.EnrollmentDate}\n");
			if (ModelState.IsValid)
			{
				_manager.EnrollmentService.UpdateOneEnrollmentGrade(enrollmentDto);
				return RedirectToAction("Enrollments");
			}
			return RedirectToAction("Enrollments");
		}
	}
}
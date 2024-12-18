using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using Entities.Dtos;

namespace ManagementSystem.Controllers
{
	public class StudentController : Controller
	{
		private readonly IServiceManager _manager;

		public StudentController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Students()
		{
			var students = _manager.StudentService.GetAllStudents(false).ToList();
			return View(students);
		}

		public IActionResult Get(int id)
		{
			var student = _manager.StudentService.GetStudentById(id, false);

			decimal totalCredits = 0m;
			decimal totalGradePoints = 0m;

			foreach (var enrollment in student.Enrollments)
			{
				if (enrollment.Grade.HasValue)
				{
					var grade = enrollment.Grade.Value;
					var course = enrollment.Course;

					totalCredits += course.Credits;
					totalGradePoints += grade * course.Credits;
				}
			}

			decimal averageGrade = totalCredits > 0 ? totalGradePoints / totalCredits : 0m;
			ViewBag.AverageGrade = averageGrade;

			return View(student);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] Student student)
		{
			if (ModelState.IsValid)
			{
				student.EnrollmentDate = DateTime.Now;

				var (isSuccess, message) = _manager.StudentService.CreateStudent(student);

				ViewBag.Message = message;
				ViewBag.Success = isSuccess;

				if (isSuccess)
				{
					return View("Students", _manager.StudentService.GetAllStudents(false).ToList());
				}
			}
			return View();
		}

		public IActionResult Edit(int id)
		{
			var student = _manager.StudentService.GetStudentById(id, true);
			return View(student);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromForm] StudentDtoForUpdate studentDto)
		{
			if (ModelState.IsValid)
			{
				var (isSuccess, message) = _manager.StudentService.UpdateOneStudent(studentDto);

				ViewBag.Message = message;
				ViewBag.Success = isSuccess;

				if (isSuccess)
					return View("Students", _manager.StudentService.GetAllStudents(false).ToList());
			}
			return View(studentDto);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Deactivate(int id)
		{
			var student = _manager.StudentService.GetStudentById(id, false);
			if (student.Status != "Active")
				return BadRequest("Only active users can be deactivated.");
			var (isSuccess, message) = _manager.StudentService.DeactivateStudent(id);
			
			ViewBag.Message = message;
			ViewBag.Success = isSuccess;
			return View("Students", _manager.StudentService.GetAllStudents(false).ToList());
		}
	}
}
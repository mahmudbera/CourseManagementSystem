using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;

namespace ManagementSystem.Controllers
{
	public class StudentController : Controller
	{
		private readonly IServiceManager _manager;

        public StudentController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult AllStudent()
		{
			var students = _manager.StudentService.GetAllStudents(false).ToList();
			return View(students);
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
				_manager.StudentService.CreateStudent(student);
				return RedirectToAction("AllStudent");
			}
			return View(student);
		}

		public IActionResult Get(int id)
		{
			var student = _manager.StudentService.GetStudentById(id, false);
			return View(student);
		}

		public IActionResult Edit(int id)
		{
			var student = _manager.StudentService.GetStudentById(id, true);
			return View(student);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromForm] Student student)
		{
			if (ModelState.IsValid)
			{
				//_manager.StudentService.UpdateStudent(student);
				return RedirectToAction("AllStudent");
			}
			return View(student);
		}

		public IActionResult Delete(int id)
		{
			_manager.StudentService.DeleteStudent(id);
			return RedirectToAction("AllStudent");
		}
	}
}
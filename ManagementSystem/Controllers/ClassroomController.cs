using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace ManagementSystem.Controllers
{
	public class ClassroomController : Controller
	{
		private readonly IServiceManager _manager;

		public ClassroomController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Classrooms()
		{
			var classrooms = _manager.ClassroomService.GetAllClassrooms(false).ToList();
			return View(classrooms);
		}

		public IActionResult Details(int id)
		{
			var classroom = _manager.ClassroomService.GetClassroomById(id, false);
			return View(classroom);
		}

		public IActionResult Edit(int id)
		{
			var classroom = _manager.ClassroomService.GetClassroomById(id, true);

			var courses = _manager.CourseService.GetAllCourses(false);
			var availableCourses = courses.Where(c => (c.Classroom == null || c.Classroom.ClassroomId == id) && c.Status.Equals("Active"));

			ViewBag.Courses = availableCourses.Select(c => new SelectListItem
			{
				Value = c.CourseId.ToString(), // Kurs ID'si
				Text = c.CourseName           // Kurs Adı
			}).ToList();

			return View(classroom);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ClassroomDtoForUpdate classroomDto)
		{
			_manager.ClassroomService.UpdateClassroom(classroomDto);
			return RedirectToAction("Classrooms");
		}

		public IActionResult Create()
		{
			var courses = _manager.CourseService.GetAllCourses(false);

			var availableCourses = courses.Where(c => c.Classroom == null && c.Status.Equals("Active"));

			ViewBag.Courses = availableCourses.Select(c => new SelectListItem
			{
				Value = c.CourseId.ToString(),
				Text = c.CourseName
			}).ToList();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Classroom classroom)
		{
			_manager.ClassroomService.CreateClassroom(classroom);
			return RedirectToAction("Classrooms");
		}
	}
}
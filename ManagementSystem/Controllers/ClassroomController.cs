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
			var availableCourses = _manager.CourseService.GetAvailableCourses(id);

			ViewBag.Courses = availableCourses.Select(c => new SelectListItem
			{
				Value = c.CourseId.ToString(),
				Text = c.CourseName
			}).ToList();

			return View(classroom);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ClassroomDtoForUpdate classroomDto)
		{
			if (ModelState.IsValid)
			{
				var (isSuccess, message) = _manager.ClassroomService.UpdateClassroom(classroomDto);
				ViewBag.Message = message;
				ViewBag.Success = isSuccess;
				return View("Classrooms", _manager.ClassroomService.GetAllClassrooms(false).ToList());
			}
			else
			{
				ViewBag.Message = "Please correct the errors in the form.";
				ViewBag.Success = false;
				return View();
			}
		}

		public IActionResult Create()
		{
			var availableCourses = _manager.CourseService.GetAvailableCoursesForNewClassroom();

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
			if (ModelState.IsValid)
			{
				var (isSuccess, message) = _manager.ClassroomService.CreateClassroom(classroom);

				ViewBag.Message = message;
				ViewBag.Success = isSuccess;
			}
			else
			{
				ViewBag.Message = "Please correct the errors in the form.";
				ViewBag.Success = false;
			}
			return View("Classrooms", _manager.ClassroomService.GetAllClassrooms(false).ToList());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			var result = _manager.ClassroomService.DeleteClassroomById(id);

			if (result.Success)
			{
				ViewBag.Message = result.Message;
				ViewBag.Success = true;
			}
			else
			{
				ViewBag.Message = result.Message;
				ViewBag.Success = false;
			}

			return View("Classrooms", _manager.ClassroomService.GetAllClassrooms(false).ToList());
		}
	}
}
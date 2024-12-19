using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ManagementSystem.Controllers
{
	public class InstructorController : Controller
	{
		private readonly IServiceManager _manager;

		public InstructorController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Instructors()
		{
			var instructors = _manager.InstructorService.GetAllInstructors(false).ToList();
			var message = TempData["Message"];
			var success = TempData["Success"];

			if (message != null)
			{
				ViewBag.Message = message.ToString();
				ViewBag.Success = Convert.ToBoolean(success);
			}
			return View(instructors);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromForm] InstructorDtoForUpdate instructorDto)
		{
			if (ModelState.IsValid)
			{
				var (isSuccess, message) = _manager.InstructorService.UpdateOneInstructor(instructorDto);

				TempData["Message"] = message;
				TempData["Success"] = isSuccess;
			}

			return RedirectToAction("Instructors");
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] Instructor instructor)
		{
			if (ModelState.IsValid)
			{
				var (isSuccess, message) = _manager.InstructorService.CreateInstructor(instructor);

				if (isSuccess)
				{
					ViewBag.Message = message;
					ViewBag.Success = isSuccess;
					return View("Instructors", _manager.InstructorService.GetAllInstructors(false).ToList());
				}
				else
				{
					ViewBag.Message = message;
					return View("Create");
				}
			}
			else
			{
				ViewBag.ErrorMessage = "Please correct the errors in the form.";
				return View("Create");
			}
		}

		public IActionResult Delete(int id)
		{
			var (isSuccess, message) = _manager.InstructorService.DeleteInstructor(id);

			ViewBag.Success = isSuccess;
			ViewBag.message = message;

			return View("Instructors", _manager.InstructorService.GetAllInstructors(false).ToList());
		}
	}
}
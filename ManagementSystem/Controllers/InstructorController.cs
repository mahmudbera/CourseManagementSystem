using Entities.Dtos;
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
			return View(instructors);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromForm] InstructorDtoForUpdate instructorDto)
		{
			if (ModelState.IsValid)
			{
				_manager.InstructorService.UpdateOneInstructor(instructorDto);
			}
			return RedirectToAction("Instructors");
		}

	}
}
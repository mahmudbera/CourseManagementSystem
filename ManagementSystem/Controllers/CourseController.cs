using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controller
{
	public class CourseController : Microsoft.AspNetCore.Mvc.Controller
	{

		[HttpGet]
		public IActionResult CourseDetail(int id)
		{
			return View();
		}
	}
}
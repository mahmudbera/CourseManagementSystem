using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
	public class CourseController : Controller
	{

		[HttpGet]
		public IActionResult CourseDetail(int id)
		{
			return View();
		}
	}
}